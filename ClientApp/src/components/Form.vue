<template>
    <v-card height="100%">
        <v-progress-circular class="loader" indeterminate v-if="isLoading"></v-progress-circular>
        <div class="subtitle" v-else>Upload a text file or use a url to get top ten words sorted by occurrences</div>
        <v-card-text>
            <v-form>
                <v-layout row wrap>
                    <v-flex xs6>
                        <v-text-field placeholder="Url" @change="onUrlChange"></v-text-field>
                    </v-flex>
                    <v-flex xs6>
                        <v-file-input
                        show-size
                        label="File input"
                        @change="onSelectFile"
                        ></v-file-input>
                    </v-flex>
                </v-layout>
                <v-row>
                    <v-col>
                        <v-btn @click="onSubmit">Submit</v-btn>
                    </v-col>
                </v-row>
                <v-row>
                    <v-col v-if="errorMessage !== ''"  class="error-message">
                        <span>{{errorMessage}}</span>
                    </v-col>
                </v-row>
            </v-form>
        </v-card-text>
    </v-card>
</template>

<script lang="ts">
    import Vue from "vue"
    import Component from "vue-class-component"
    import { Prop } from "vue-property-decorator"

    @Component({})
    export default class Form extends Vue {
        @Prop({ required: true})
        private isLoading!: boolean
        @Prop({ required: true})
        private errorMessage!: string
        @Prop({ required: true})
        private url!: string

        private onSelectFile(file: File) {
            this.$emit("onSelectFile", file)
        }

        private onSubmit() {
            this.$emit("onSubmit")
        }

        private onUrlChange(url: string){
            this.$emit("onUrlChange", url)
        }
    }
</script>

<style lang="scss" scoped>
.error-message {
    color: red;
}
.loader {
    margin: 5px;
}
.subtitle {
    padding: 10px;
}
</style>
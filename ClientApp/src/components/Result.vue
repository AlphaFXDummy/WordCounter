<template>
    <v-card >
        <div class="subtitle">Results</div>
        <v-card-text>
            <template v-for="word in results.topTenWords">
                <v-row :key="word.id">
                    <v-col>{{word.name}}</v-col>
                    <v-col>{{word.occurrence}}</v-col>
                </v-row>
            </template>
            <v-row>
                <v-col>
                    <v-btn @click="onBackClick">Back</v-btn>
                </v-col>
            </v-row>
        </v-card-text>
    </v-card>
</template>

<script lang="ts">
    import Vue from "vue";
    import Component from "vue-class-component"
    import { Prop } from "vue-property-decorator"
    import { IWordCounter } from '@/interfaces';

    @Component({})
    export default class Result extends Vue {
        @Prop({ required: true })
        private results!: IWordCounter

        private onBackClick() {
            this.$emit("onBackClick")
        }
    }
</script>

<style scoped>

</style>
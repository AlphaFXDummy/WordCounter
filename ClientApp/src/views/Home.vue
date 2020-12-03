<template>
  <v-container>
    <Header/>
    <v-layout justify-center>
      <v-flex xs6>
        <v-row class="top-buffer">
          <v-col align="center">
            <Form
              v-if="!results.topTenWords"
              :isLoading="isLoading"
              :errorMessage="errorMessage"
              :url="url"
              @onSelectFile="onSelectFile"
              @onUrlChange="onUrlChange"
              @onSubmit="onSubmit"
            />
            <Result v-else
              :results="results"
              @onBackClick="onBackClick"
            />
          </v-col>
        </v-row>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script lang="ts">
  import Vue from "vue";
  import Component from "vue-class-component"
  import { WordCounterService } from "@/api"
  import { IWordCounter } from "@/interfaces"
  import { AxiosResponse } from "axios"
  import Header from "../components/Header.vue"
  import Form from "../components/Form.vue"
  import Result from "../components/Result.vue"

  @Component({
    components: {
      Header,
      Form,
      Result
    }
  })
  export default class Home extends Vue {
    private file!: File | undefined
    private url = ""
    private errorMessage = ""
    private results: IWordCounter = {} as IWordCounter
    private isLoading = false;

    private onSelectFile(file: File) {
      this.file = file;
    }

    private onSubmit() {
      if(this.errorMessage !== "") this.errorMessage = ""
      if(this.file !== undefined) {
        this.isLoading = true
        new WordCounterService().uploadFile(this.file).then((response: AxiosResponse<IWordCounter>) => {
          this.results = response.data
        // eslint-disable-next-line @typescript-eslint/no-explicit-any
        }).catch((errorResponse: any) => {
          this.errorMessage = errorResponse.response.data.errors.File[0]
        }).finally(() => this.isLoading = false)
      } else if (this.url !== "") {
        this.isLoading = true
        if(this.validateUrl(this.url)) {
          new WordCounterService().getWordCountByUrl(this.url).then((response: AxiosResponse<IWordCounter>) => {
            this.results = response.data
          }).catch(() => this.errorMessage = "Could not find text at that URL").finally(() => this.isLoading = false)
        } else {
          this.errorMessage = "Please supply a valid URL"
        }
      } else {
        this.errorMessage = "Please supply either a URL or File"
      }
    }

    private onBackClick() {
      this.errorMessage = ""
      this.results = {} as IWordCounter
      this.file = undefined
      this.url = ""
    }

    private validateUrl(url: string): boolean {
      const expression = /[-a-zA-Z0-9@:%._~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_.~#?&//=]*)?/gi;
      const regex = new RegExp(expression);
      return url.match(regex) !== null
    }

    private onUrlChange(url: string) {
      this.url = url
    }
  }
</script>

<style lang="scss" scoped>
.top-buffer { margin-top: 30px;}
</style>

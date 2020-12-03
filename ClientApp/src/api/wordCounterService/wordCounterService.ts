import WordCounterApi from "./api";
import { IApi, IWordCounter } from "@/interfaces";
import { AxiosPromise } from "axios";

export default class WordCounterService {
    private api: IApi;
    private controllerName = "api/WordCounter";

    constructor() {
        this.api = new WordCounterApi();
    }

    public uploadFile(file: File): AxiosPromise<IWordCounter> {
        const formData = new FormData();
        formData.append("file", file);
        return this.api.Post(`${this.controllerName}/UploadFile`, formData ,{  headers: { 'Content-Type': 'multipart/form-data' }});
    }

    public getWordCountByUrl(url: string): AxiosPromise<IWordCounter> {
        return this.api.Get(`${this.controllerName}/getWordCountByUrl`, {
            params: { url },
        });
    }
}


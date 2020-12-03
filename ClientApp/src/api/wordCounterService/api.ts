import Api from "../api";
import { AxiosRequestConfig, AxiosResponse } from "axios";
import getConfig from "./constants";
import { IApi } from "@/interfaces";

export default class WordCounterApi implements IApi {
    private api: Api;

    constructor() {
        this.api = new Api(getConfig().requestConfig);
    }

    public Get(
        url: string,
        config?: AxiosRequestConfig | undefined
    ): Promise<AxiosResponse<any>> {
        return this.api.Get(url, config);
    }

    public Post(
        url: string,
        data?: any,
        config?: AxiosRequestConfig | undefined
    ): Promise<AxiosResponse<any>> {
        return this.api.Post(url, data, config);
    }

    public Put(
        url: string,
        data?: any,
        config?: AxiosRequestConfig | undefined
    ): Promise<AxiosResponse<any>> {
        return this.api.Put(url, data, config);
    }

    public Delete(
        url: string,
        config?: AxiosRequestConfig | undefined
    ): Promise<AxiosResponse<any>> {
        return this.api.Delete(url, config);
    }

    public Patch(
        url: string,
        data?: any,
        config?: AxiosRequestConfig | undefined
    ): Promise<AxiosResponse<any>> {
        return this.api.Patch(url, data, config);
    }
}

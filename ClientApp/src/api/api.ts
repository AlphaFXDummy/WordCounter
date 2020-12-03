import axios, { AxiosInstance, AxiosRequestConfig, AxiosResponse } from "axios";
import { IApi } from "../interfaces";

export default class Api implements IApi {
    private api: AxiosInstance;

    constructor(config: AxiosRequestConfig) {
        this.api = axios.create(config);
    }

    public Get(
        url: string,
        config?: AxiosRequestConfig
    ): Promise<AxiosResponse<any>> {
        return this.api.get(url, config);
    }

    public Post(
        url: string,
        data?: any,
        config?: AxiosRequestConfig
    ): Promise<AxiosResponse<any>> {
        return this.api.post(url, data, config);
    }

    public Put(
        url: string,
        data?: any,
        config?: AxiosRequestConfig
    ): Promise<AxiosResponse<any>> {
        return this.api.put(url, data, config);
    }

    public Delete(
        url: string,
        config?: AxiosRequestConfig
    ): Promise<AxiosResponse<any>> {
        return this.api.delete(url, config);
    }

    public Patch(
        url: string,
        data?: any,
        config?: AxiosRequestConfig
    ): Promise<AxiosResponse<any>> {
        return this.api.patch(url, data, config);
    }

    public ComposeUrl(action: string, prefix?: string): string {
        let url = action;
        if (prefix) {
            url = prefix.endsWith("/") ? `${prefix}${action}` : `${prefix}/${action}`;
        }

        return url;
    }

    public PostWithDuplicationSupport(
        url: string,
        data?: any,
        config?: AxiosRequestConfig
    ): Promise<AxiosResponse<any>> {
        return this.api.post(url, data, config);
    }
}

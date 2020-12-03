import { AxiosRequestConfig, AxiosResponse } from "axios";

export default interface IAxios {
    Get(url?: string, config?: AxiosRequestConfig): Promise<AxiosResponse<any>>;
    Post(
        url?: string,
        data?: any,
        config?: AxiosRequestConfig
    ): Promise<AxiosResponse<any>>;
    Put(
        url?: string,
        data?: any,
        config?: AxiosRequestConfig
    ): Promise<AxiosResponse<any>>;
    Delete(
        url?: string,
        config?: AxiosRequestConfig
    ): Promise<AxiosResponse<any>>;
    Patch(
        url?: string,
        data?: any,
        config?: AxiosRequestConfig
    ): Promise<AxiosResponse<any>>;
}

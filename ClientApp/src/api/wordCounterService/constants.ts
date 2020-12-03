import { AxiosRequestConfig } from "axios";

const getConfig = (): any => {
    return {
        requestConfig: {
            baseURL: "https://localhost:5001/",
            timeout: 60000,
        } as AxiosRequestConfig,
    };
};

export default getConfig;

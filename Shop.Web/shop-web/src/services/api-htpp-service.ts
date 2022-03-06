import axios from "axios";
import { config } from "../config";
import { ApiResult } from "../models/api-result";


export class ApiHttpServise {
    get<T>(path: string) {
        return new Promise<ApiResult<T>>((resolve, reject) => {
            axios.get<ApiResult<T>>(`${config.url}${path}`).then(result => {
                resolve(result.data);
            }).catch((error) => {
                resolve({
                    isError: true
                });
            });
        });

    }

    post<T>(path: string, data?: any) {
        return new Promise<ApiResult<T>>((resolve, reject) => {
            axios.post<ApiResult<T>>(`${config.url}${path}`, data).then(result => {
                resolve(result.data);
            }).catch((error) => {
                resolve({
                    isError: true
                });
            });
        });

    }
}
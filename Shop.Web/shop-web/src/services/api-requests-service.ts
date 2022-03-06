import { ApiResult } from "../models/api-result";
import { Order } from "../models/order";
import { Product } from "../models/product";
import { ApiHttpServise } from "./api-htpp-service";

export class ApiRequestService {
    private apiHttpService = new ApiHttpServise();

    getProducts(): Promise<ApiResult<Product[]>> {
        return this.apiHttpService.get(`/api/products`);
    }

    getFormOrder(): Promise<ApiResult<Order>> {
        return this.apiHttpService.get(`/api/orders/form-order`);
    }

    addOrder(): Promise<ApiResult<null>> {
        return this.apiHttpService.post(`/api/orders/add-order`);
    }

    addProductToFormOrder(prodductId: number): Promise<ApiResult<null>> {
        return this.apiHttpService.post(`/api/orders/form-order/add/${prodductId}`);
    }
}
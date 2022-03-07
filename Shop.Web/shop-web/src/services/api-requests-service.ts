import { OrderInformation } from "../compoents/order-information";
import { ApiResult } from "../models/api-result";
import { Order } from "../models/order";
import { OrderInformationModel } from "../models/order-inforamation";
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

    getOrders(): Promise<ApiResult<Order[]>> {
        return this.apiHttpService.get(`/api/orders`);
    }

    getOrder(orderId: number): Promise<ApiResult<Order>> {
        return this.apiHttpService.get(`/api/orders/${orderId}`);
    }


    addOrder(): Promise<ApiResult<null>> {
        return this.apiHttpService.post(`/api/orders/add-order`);
    }

    addProductToFormOrder(prodductId: number): Promise<ApiResult<null>> {
        return this.apiHttpService.post(`/api/orders/form-order/add/${prodductId}`);
    }

    removeProductFromFormOrder(prodductId: number): Promise<ApiResult<null>> {
        return this.apiHttpService.post(`/api/orders/form-order/remove/${prodductId}`);
    }

    payOrder(information: OrderInformationModel): Promise<ApiResult<null>> {
        return this.apiHttpService.post(`/api/orders/form-order/pay`, information);
    }

    completeOrder(orderid: number): Promise<ApiResult<null>> {
        return this.apiHttpService.post(`/api/orders/${orderid}/complete`);
    }
}
import { OrderState } from "./order-state";
import { Product } from "./product";

export class Order {
    public id?: number;
    public state?: OrderState;

    public products?: OrderProduct[];
}

export class OrderProduct {
    public product?: Product;
    public count?: number;
}



import { LogLevel } from "./log-level";
import { OrderState } from "./order-state";
import { OrderProduct } from "./order-product";
import { Log } from "./log-model";
import { OrderInformationModel } from "./order-inforamation";


export class Order {
    public id?: number;
    public state?: OrderState;

    public products?: OrderProduct[];

    public logs?: Log[];

    public information?: OrderInformationModel;
}


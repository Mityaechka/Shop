import { OrderState } from "./order-state";
import { Product } from "./product";

export class Order {
    public id?: number;
    public state?: OrderState;

    public products?: OrderProduct[];

    public logs?: Log[];
}

export class OrderProduct {
    public product?: Product;
    public count?: number;
}

export class Log {
    public id!: number;
    public message!: number;
    public level!: number;
}

export enum LogLevel {
    Info,
    Warning,
    Error
}
export namespace LogLevel {
    export function toString(level: LogLevel): string {
        switch (level) {
            case 0: return "Информация";
            case 1: return "Предупреждение";
            case 2: return "Ошибка";
        }
        return "";
    }
}
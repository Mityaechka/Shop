
export enum OrderState {
    Form,
    Paied,
    Confirmed
}

export namespace OrderState {
    export function toString(state: OrderState): string {
        switch (state) {
            case 0: return "Формируется";
            case 1: return "Оплачен";
            case 2: return "Подтвержден";
        }
        return "";
    }
}
import React from "react";
import { OrderInformationModel } from "../models/order-inforamation";

class OrderInformationState {
    isLoading: boolean = false;

    address!: string;
    cardNumber!: string;
}

class OrderInformationProps {
    hideOrderInformaionEvent!: Function;
    payOrderEvent!: (information: OrderInformationModel) => void;
}

export class OrderInformation extends React.Component<OrderInformationProps, OrderInformationState> {
    state: OrderInformationState = {
        isLoading: false,
        address: "",
        cardNumber: ""
    }

    constructor(p: OrderInformationProps) {
        super(p)

        this.onChangeCardNumber = this.onChangeCardNumber.bind(this);
        this.onChangeAddress = this.onChangeAddress.bind(this);
    }

    render() {
        const { hideOrderInformaionEvent, payOrderEvent } = this.props;
        const { address, cardNumber } = this.state;
        return <div>
            <h2>Введите данные заказа</h2>

            <p>Адрес доставки</p>
            <input onChange={this.onChangeAddress} value={address} />

            <p>Номер карты</p>
            <input onChange={this.onChangeCardNumber} value={cardNumber} />

            <div>
                <button onClick={() => payOrderEvent({ address, cardNumber })} disabled={!this.isFormValid()}>Оплатить заказ</button>
            </div>

            <div>
                <button onClick={() => hideOrderInformaionEvent()}>Отмена</button>
            </div>
        </div>
    }

    onChangeAddress(e: React.FormEvent<HTMLInputElement>) {
        let value = e.currentTarget.value;

        this.setState({
            address: value
        })
    }

    onChangeCardNumber(e: React.FormEvent<HTMLInputElement>) {
        let value = e.currentTarget.value;

        this.setState({
            cardNumber: value
        })
    }

    isFormValid(): boolean {
        const { address, cardNumber } = this.state;
        return address != "" && cardNumber != "" && cardNumber.length == 16;
    }
}
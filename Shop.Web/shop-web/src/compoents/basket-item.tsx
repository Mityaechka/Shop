import React from "react";
import { OrderProduct } from "../models/order";

class BasketItemProps {
    public product?: OrderProduct;
}

export class BasketItem extends React.Component<BasketItemProps> {
    constructor(props: BasketItemProps) {
        super(props)
    }

    render() {
        return <div >
            <p style={{ display: 'inline' }}>{this.props.product!.product!.name}</p>
            <p style={{ display: 'inline' }}>Цена: {this.props.product!.product!.price}</p>
            <p style={{ display: 'inline' }}>Кол-во: {this.props.product!.count}</p>
        </div >;
    }
}
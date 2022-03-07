import React from "react";
import { config } from "../config";
import { Product } from "../models/product";

class ProductCardProps {
    public product?: Product;
    public addProduct?: Function;
    public removeProduct?: Function;
}

export class ProductCard extends React.Component<ProductCardProps> {
    constructor(props: ProductCardProps) {
        super(props)
    }

    render() {
        return <div className="procuct-card__body">
            <h6 className="procuct-card__title">{this.props.product?.name}</h6>
            <img className="procuct-card__img" src={config.url + this.props.product?.imagePath} />
            <p>Цена: {this.props.product?.price} тг.</p>
            <div className="procuct-card__buttons">
                <button className="procuct-card__add-btn" onClick={() => this.props.addProduct!()}>+</button>
                <button className="procuct-card__remove-btn" onClick={() => this.props.removeProduct!()}>-</button>
            </div>
        </div>;
    }
}
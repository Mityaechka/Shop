import React from "react";
import { Product } from "../models/product";

class ProductCardProps {
    public product?: Product;
    public addProduct?: Function;
}

export class ProductCard extends React.Component<ProductCardProps> {
    constructor(props: ProductCardProps) {
        super(props)
    }

    render() {
        return <div>
            <h6 className="procuct-card__title">{this.props.product?.name}</h6>
            <img className="procuct-card__img" src={this.props.product?.imagePath} />
            <p>Цена: {this.props.product?.price} тг.</p>
            <div className="procuct-card__buttons">
                <button className="procuct-card__add-btn" onClick={() => this.props.addProduct!()}>+</button>
                <button className="procuct-card__remove-btn">-</button>
            </div>
        </div>;
    }
}
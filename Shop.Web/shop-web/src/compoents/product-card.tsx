import React from "react";
import { Product } from "../models/product";


export class ProductCard extends React.Component<Product> {
    constructor(props: Product) {
        super(props)
    }

    render() {
        return <div>
            <h6 className="procuct-card__title">{this.props.name}</h6>
            <img className="procuct-card__img" src={this.props.imagePath} />
            <p>Цена: {this.props.price} тг.</p>
            <div className="procuct-card__buttons">
                <button className="procuct-card__add-btn">+</button>
                <button className="procuct-card__remove-btn">-</button>
            </div>
        </div>;
    }
}
import React from "react";
import { Product } from "../models/product";
import { ProductCard } from "./product-card";

export class ProductList extends React.Component<{products : Product[]}> {
    constructor(props: {products : Product[]}) {
        super(props)
    }

    render() {
        return <div className='products-list__body'>
            {this.props.products.map(product => <ProductCard name={product.name} imagePath={product.imagePath} price={product.price} />)}
        </div>
    }
}
import React from "react";
import { config } from "../config";
import { Product } from "../models/product";
import { ApiRequestService } from "../services/api-requests-service";
import { ProductCard } from "./product-card";

class ProductsListState {
    isLoading: boolean = false;
    isError: boolean = false;
    products: Product[] = [];
}

export class ProductList extends React.Component<{}, ProductsListState> {
    state: ProductsListState = {
        isLoading: false,
        products: [],
        isError: false
    }

    private apiRequestsService = new ApiRequestService();

    constructor({ }) {
        super({})

        this.loadingProducts = this.loadingProducts.bind(this);
    }



    componentDidMount() {
        this.loadingProducts();
    }

    loadingProducts() {
        this.setState((previousState, props) => ({
            isLoading: true,
            isError: false
        }));

        this.apiRequestsService.getProducts().then(result => {
            this.setState((previousState, props) => ({
                isLoading: false
            }));

            if (result.isError) {
                this.setState((previousState, props) => ({
                    isError: true
                }));

                return;
            }

            this.setState((previousState, props) => ({
                products: result.data ?? []
            }));

        });
    }

    render() {
        const { isLoading, products, isError } = this.state;
        if (isLoading) {
            return this.renderLoading();
        }

        if (isError) {
            return this.renderError()
        }

        return this.renderProducts(products);
    }

    renderLoading() {
        return <div>
            <p>Загрузка данных</p>
        </div>
    }

    renderProducts(products: Product[]) {
        return <div className='products-list__body'>
            {products.map((product, i) => <ProductCard key={i} product={product} addProduct={() => this.addProductToFormOrder(product.id!)}/>)}
        </div>
    }

    renderError() {
        return <div>
            <p>Ошибка загрузки данных</p>
            <button onClick={this.loadingProducts}>Повторить попытку</button>
        </div>
    }

    addProductToFormOrder(productId: number) {
        this.apiRequestsService.addProductToFormOrder(productId);
    }
}
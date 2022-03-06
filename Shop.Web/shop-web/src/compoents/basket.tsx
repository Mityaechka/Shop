import React from "react";
import { Order, OrderProduct } from "../models/order";
import { ApiRequestService } from "../services/api-requests-service";
import { BasketItem } from "./basket-item";

class BasketState {
    isLoading: boolean = false;
    isError: boolean = false;
    hasOrder: boolean = false;
    order?: Order;
}

export class Basket extends React.Component<{}, BasketState> {
    state: BasketState = {
        isLoading: false,
        hasOrder: false,
        isError: false,
        order: undefined
    }

    private apiRequestsService = new ApiRequestService();

    constructor({ }) {
        super({})

        this.loadingOrder = this.loadingOrder.bind(this);
        this.addOrder = this.addOrder.bind(this);
    }
    componentDidMount() {
        this.loadingOrder();
    }


    loadingOrder() {
        this.setState((previousState, props) => ({
            isLoading: true,
            isError: false,
            hasOrder: true
        }));

        this.apiRequestsService.getFormOrder().then(result => {
            this.setState((previousState, props) => ({
                isLoading: false
            }));

            if (result.isError) {
                this.setState((previousState, props) => ({
                    isError: true
                }));

                return;
            }

            if (!result.data) {
                this.setState((previousState, props) => ({
                    hasOrder: false
                }));

                return;
            }

            this.setState((previousState, props) => ({
                order: result.data
            }));

        });
    }

    addOrder() {
        this.setState((previousState, props) => ({
            isLoading: true,
            isError: false
        }));

        this.apiRequestsService.addOrder().then(result => {
            this.loadingOrder()
        });
    }
    render() {
        const { isLoading, order, isError, hasOrder } = this.state;

        if (isLoading) {
            return this.renderLoading();
        }
        if (isError) {
            return
        }
        if (!hasOrder) {
            return this.renderCreateOrder();
        }

        return this.renderBasket(order!)
    }

    renderBasket(order: Order) {
        if (!order)
            return <div></div>;

        if (order.products?.length == 0) {
            return <div>
                <p>Вы еще не добавили ни одного заказа</p>
            </div>
        }

        return <div>
            <p>Ваш заказ</p>
            <div>
                {order.products?.map((product, i) => <BasketItem product={product!} key={i} />)}
            </div>
            <button>Подтвердить заказ</button>
        </div>
    }

    renderCreateOrder() {
        return <div>
            <p>У Вас нет активного заказа</p>
            <button onClick={this.addOrder}>Создать заказ</button>
        </div>
    }

    renderLoading() {
        return <div>
            <p>Загрузка данных</p>
        </div>
    }

    renderError() {
        return <div>
            <p>Ошибка загрузки Вашего заказа</p>
            <button onClick={this.loadingOrder}>Повторить попытку</button>
        </div>
    }

    confirmOrder() {

    }
}
import React from "react";
import { Order } from "../models/order";
import { OrderProduct } from "../models/order-product";
import { ApiRequestService } from "../services/api-requests-service";

class BasketState {
    isLoading: boolean = false;
    isError: boolean = false;
    hasOrder: boolean = false;
    order?: Order;
}

class BasketProps {
    showOrderInformaionEvent!: Function;
}


export class Basket extends React.Component<BasketProps, BasketState> {
    state: BasketState = {
        isLoading: false,
        hasOrder: false,
        isError: false,
        order: undefined
    }

    private apiRequestsService = new ApiRequestService();

    constructor(p: BasketProps) {
        super(p)

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
        const { showOrderInformaionEvent } = this.props;

        if (isLoading) {
            return this.renderLoading();
        }
        if (isError) {
            return
        }
        if (!hasOrder) {
            return this.renderCreateOrder();
        }

        return this.renderBasket(order!, showOrderInformaionEvent!)
    }

    renderBasket(order: Order, showInfoamationEvent: Function) {
        if (!order)
            return <div></div>;

        if (order.products?.length == 0) {
            return <div>
                <h2>?????? ??????????</h2>
                <p>???? ?????? ???? ???????????????? ???? ???????????? ????????????</p>
            </div>
        }

        return <div>
            <h2>?????? ??????????</h2>
            <table style={{ width: '100%', height: '50%' }}>
                <tr>
                    <th style={{ textAlign: 'left' }}>????????????????????????</th>
                    <th style={{ textAlign: 'left' }}>????????</th>
                    <th style={{ textAlign: 'left' }}>??????-????</th>
                    <th style={{ textAlign: 'left' }}>??????????????????</th>
                </tr>
                <tbody>
                    {order.products?.map((product, i) => this.renderItem(product!))}
                </tbody>
                <tfoot>
                    <tr>
                        <th id="total" colSpan={3} style={{ textAlign: 'left' }}>?????????? ??????????????????:</th>
                        <td>{order.products!.reduce((previousValue, currentValue) => previousValue + currentValue.count! * currentValue.product?.price!, 0)}</td>
                    </tr>
                </tfoot>
            </table>

            <button onClick={() => showInfoamationEvent()}>?????????????????????? ??????????</button>
        </div>
    }

    renderCreateOrder() {
        return <div>
            <h2>?????? ??????????</h2>
            <p>?? ?????? ?????? ?????????????????? ????????????</p>
            <button onClick={this.addOrder}>?????????????? ??????????</button>
        </div>
    }

    renderLoading() {
        return <div>
            <p>???????????????? ????????????</p>
        </div>
    }

    renderError() {
        return <div>
            <p>???????????? ???????????????? ???????????? ????????????</p>
            <button onClick={this.loadingOrder}>?????????????????? ??????????????</button>
        </div>
    }

    renderItem(product: OrderProduct) {
        return <tr >
            <td>{product!.product!.name}</td>
            <td>{product!.product!.price}</td>
            <td>{product!.count}</td>
            <td>{product!.count! * product!.product!.price!}</td>
        </tr >;
    }

    confirmOrder() {

    }
}
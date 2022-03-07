import React, { ComponentProps } from "react";
import { useParams } from "react-router-dom";
import { Log, LogLevel, Order, OrderProduct } from "../models/order";
import { OrderState } from "../models/order-state";
import { ApiRequestService } from "../services/api-requests-service";



class OrderDetailsState {
    isLoading!: boolean;
    order?: Order;
}


class OrderDetailsParams {
    public id!: string;
}


export class OrderDetailsPage extends React.Component<{} | any, OrderDetailsState> {
    state: Readonly<OrderDetailsState> = {
        order: undefined,
        isLoading: false
    }
    private orderId!: number;

    private apiRequestService = new ApiRequestService();

    constructor(p: any) {
        super(p);

        try {
            this.orderId = Number.parseInt(window.location.pathname.split("/").slice(-1)[0]);
        } catch { }

        this.completeOrder = this.completeOrder.bind(this);
    }

    completeOrder() {
        this.setState({ isLoading: true });
        this.apiRequestService.completeOrder(this.orderId).then(result => {
            this.loadingOrder();
        });
    }

    componentDidMount() {
        this.loadingOrder();
    }

    loadingOrder() {
        this.setState({ isLoading: true });

        this.apiRequestService.getOrder(this.orderId).then(result => {
            this.setState({ isLoading: false });

            if (result.isError) {
                return;
            }

            this.setState({ order: result.data! });
        })
    }

    render() {
        const { isLoading, order } = this.state;

        if (isLoading) {
            return this.renderLoading();
        }

        return this.renderOrder(order!);
    }

    renderOrder(order: Order) {
        if (!order) {
            return <div></div>;
        }
        return <div>
            <h2>Заказ #{order.id}</h2>
            <p>Состояние: {OrderState.toString(order.state!)}</p>
            {
                order.state! == OrderState.Paied ?
                    <div><button onClick={this.completeOrder}>Подтвердить заказ</button></div>
                    :
                    <div></div>
            }

            <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr' }}>
                <div>
                    <h3>Продукты</h3>
                    {this.renderProducts(order.products!)}
                </div>

                <div>
                    <h3>Логи</h3>
                    {this.renderLogs(order.logs!)}
                </div>
            </div>
        </div>
    }

    renderLoading() {
        return <div>Загрузка данных</div>
    }

    renderLogs(logs: Log[]) {
        return <div>
            <table style={{ width:'100%'}}>
                <tr>
                    <th style={{ textAlign: 'left' }}>ID</th>
                    <th style={{ textAlign: 'left' }}>Уровень</th>
                    <th style={{ textAlign: 'left' }}>Сообщение</th>
                </tr>
                <tbody>
                    {logs.map((log, i) => this.renderLogrRow(log))}
                </tbody>
            </table>
        </div>
    }

    renderProducts(propducts: OrderProduct[]) {
        return <div>
            <table >
                <tr>
                    <th style={{ textAlign: 'left' }}>ID</th>
                    <th style={{ textAlign: 'left' }}>Уровень</th>
                    <th style={{ textAlign: 'left' }}>Сообщение</th>
                </tr>
                <tbody>
                    {propducts.map((propduct, i) => this.renderProductRow(propduct))}
                </tbody>
                <tfoot>
                    <tr>
                        <th id="total" colSpan={4} style={{ textAlign: 'left' }}>Общая стоимость:</th>
                        <td>{propducts.reduce((previousValue, currentValue) => previousValue + currentValue.count! * currentValue.product?.price!, 0)}</td>
                    </tr>
                </tfoot>
            </table>
        </div>
    }

    renderLogrRow(log: Log) {
        return <tr>
            <td>{log.id}</td>
            <td>{LogLevel.toString(log.level!)}</td>
            <td>{log.message}</td>
        </tr>
    }

    renderProductRow(product: OrderProduct) {
        return <tr>
            <td>{product.product?.id}</td>
            <td>{product.product?.name}</td>
            <td>{product.product?.price}</td>
            <td>{product.count}</td>
            <td>{product.product!.price! * product!.count!}</td>
        </tr>
    }

}
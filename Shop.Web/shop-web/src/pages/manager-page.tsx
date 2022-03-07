import React from "react";
import { Link } from "react-router-dom";
import { Order } from "../models/order";
import { OrderInformationModel } from "../models/order-inforamation";
import { OrderState } from "../models/order-state";
import { ApiRequestService } from "../services/api-requests-service";
class OrdersListProps {

}

class ManagerPageState {
    isLoading!: boolean;
    orders!: Order[];
}

export class ManagerPage extends React.Component<OrdersListProps, ManagerPageState> {

    state: ManagerPageState = {
        isLoading: false,
        orders: []
    };

    private apiRequestsService = new ApiRequestService();

    componentDidMount() {
        this.setState({ isLoading: true });
        this.apiRequestsService.getOrders().then(result => {
            this.setState({ isLoading: false });

            if (result.isError) {
                return;
            }

            this.setState({ orders: result.data! });
        });
    }

    constructor(p: OrdersListProps) {
        super(p);
    }


    render() {
        const { isLoading, orders } = this.state;

        if (isLoading) {
            return this.renderLoading();
        }

        return this.renderOrders(orders);
    }

    renderOrders(orders: Order[]) {
        return <div>
            <table>
                <tr>
                    <th>ID</th>
                    <th>Состояние</th>
                    <th></th>
                </tr>
                <tbody>
                    {orders.map((order, i) => this.renderOrderRow(order))}
                </tbody>
            </table>
        </div>
    }

    renderOrderRow(order: Order) {
        return <tr>
            <td>{order.id}</td>
            <td>{OrderState.toString(order.state!)}</td>
            <td><Link to={'/manager/orders/' + order.id}>Информация</Link></td>
        </tr>
    }


    renderLoading() {
        return <div>Загрузка данных</div>
    }


    


} 
import React from "react";
import { Basket } from "../compoents/basket";
import { OrderInformation } from "../compoents/order-information";
import { ProductList } from "../compoents/products-list";
import { OrderInformationModel } from "../models/order-inforamation";
import { ApiRequestService } from "../services/api-requests-service";

class OrderPageState {
    showOrderInformation: boolean = false;
}

export class OrderPage extends React.Component<{}, OrderPageState> {
    private apiRequestsService = new ApiRequestService();

    private basketComponent!: Basket | null;

    state: OrderPageState = {
        showOrderInformation: false
    }

    constructor(p: any) {
        super(p);
    }
    render() {
        const { showOrderInformation } = this.state;

        return <div className='products-page__body'>
            <ProductList
                addProductEvent={(id) => this.addProductToFormOrderAction(id)}
                removeProductEvent={(id) => this.removeProductToFormOrderAction(id)} />

            <div >
                {!showOrderInformation ?
                    <Basket
                        showOrderInformaionEvent={() => this.showOrderInformationAction()}
                        ref={instance => { this.basketComponent = instance; }} /> :
                    <OrderInformation
                        hideOrderInformaionEvent={() => this.hideOrderInformationAction()}
                        payOrderEvent={(inforamation) => this.payOrderAction(inforamation)} />}

            </div>
        </div>
    }

    showOrderInformationAction() {
        this.setState({
            showOrderInformation: true
        });
    }

    hideOrderInformationAction() {
        this.setState({
            showOrderInformation: false
        });
    }

    payOrderAction(information: OrderInformationModel) {
        this.hideOrderInformationAction();

        this.apiRequestsService.payOrder(information).then(result => {
            this.basketComponent?.loadingOrder();
        });;
    }

    addProductToFormOrderAction(productId: number) {
        this.apiRequestsService.addProductToFormOrder(productId).then(result => {
            if (result.isError)
                return;
            this.basketComponent?.loadingOrder();
        });

    }

    removeProductToFormOrderAction(productId: number) {
        this.apiRequestsService.removeProductFromFormOrder(productId).then(result => {
            if (result.isError)
                return;

            this.basketComponent?.loadingOrder();
        });

    }
}
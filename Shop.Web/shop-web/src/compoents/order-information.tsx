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
}
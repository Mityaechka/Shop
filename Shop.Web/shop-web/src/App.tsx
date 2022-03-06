import React from 'react';
import './App.css';
import { ProductCard } from './compoents/product-card';
import { ProductList } from './compoents/products-list';
import { Product } from './models/product';
import axios from 'axios';
import { Basket } from './compoents/basket';
import { OrderPage } from './pages/order-page';




function App() {

  return (<OrderPage />);
}

export default App;

import React from 'react';
import { ProductCard } from './compoents/product-card';
import { ProductList } from './compoents/products-list';
import { Product } from './models/product';
import axios from 'axios';
import { Basket } from './compoents/basket';
import { OrderPage } from './pages/order-page';
import { ManagerPage } from './pages/manager-page';
import { OrderDetailsPage } from './pages/order-details-page';
import { BrowserRouter, Route, Router, Routes } from 'react-router-dom';



function App() {

  return <BrowserRouter>
    <Routes>
      <Route path="/" element={<OrderPage />} />
      <Route path="/manager/orders" element={<ManagerPage />} />
      <Route path="/manager/orders/:id" element={<OrderDetailsPage />} />
    </Routes>
  </BrowserRouter>;
}

export default App;

import React from 'react';
import './App.css';
import { ProductCard } from './compoents/product-card';
import { ProductList } from './compoents/products-list';
import { Product } from './models/product';
import axios from 'axios';

let products: Product[] = [{
  name: "Coca-Cola",
  imagePath: "https://dastarkhan24.kz/upload/iblock/374/37473074613364171b0b82ff8391afd1.jpg",
  price: 100
},
{
  name: "Coca-Cola",
  imagePath: "https://dastarkhan24.kz/upload/iblock/374/37473074613364171b0b82ff8391afd1.jpg",
  price: 100
},
{
  name: "Coca-Cola",
  imagePath: "https://dastarkhan24.kz/upload/iblock/374/37473074613364171b0b82ff8391afd1.jpg",
  price: 100
}, {
  name: "Coca-Cola",
  imagePath: "https://dastarkhan24.kz/upload/iblock/374/37473074613364171b0b82ff8391afd1.jpg",
  price: 100
}];


function App() {

  return (
    <div className='products-page__body'>
      <ProductList products={products} />

      <div className='products-list__body'>
      </div>
    </div>
  );
}

export default App;

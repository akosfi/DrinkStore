import Vue from 'vue'
import Vuex from 'vuex'

import products from './modules/products';
import categories from './modules/categories';
import cart from './modules/cart';
import orders from './modules/orders';

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    products,
    categories,
    cart,
    orders,
  },
  strict: true
});

import {makeRequest} from '../../util';

const state = {
    products: [],
};
const getters = {
    getProducts: function() {
        return state.products;
    }
};
const actions = {
    getProductsAction({commit}, {categoryId, subcategoryId}) {
        let url = '/api/products?';
        url += categoryId ? 'categoryId=' + categoryId : '';
        url += subcategoryId ? '&subcategoryId=' + subcategoryId : '';

        return new Promise((resolve, reject) => {
            makeRequest(url, {})
            .then((response) => {
                commit('addProducts', response.products);
                resolve(response.products);
            })
            .catch((err) => {
                console.log(err);
                reject();
            });
        });
    }
};

const mutations = {
    addProducts(state, products) {
        state.products = products;
    },
    addProduct(state, product) {
        if(state.products.find(p => p.id === product.id) != null) {
            state.products.push(product);
        }
    }
};

export default {
    namespaced: true,
    state,
    getters,
    actions,
    mutations,
};
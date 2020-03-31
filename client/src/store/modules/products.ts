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
        let url = '/products?';
        url += categoryId ? 'categoryId=' + categoryId : '';
        url += subcategoryId ? '&subcategoryId=' + subcategoryId : '';

        return new Promise((resolve, reject) => {
            makeRequest(url, {})
            .then((products) => {
                commit('addProducts', products);
                resolve(products);
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
    }
};

export default {
    namespaced: true,
    state,
    getters,
    actions,
    mutations,
};
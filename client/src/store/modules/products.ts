import {makeRequest} from '../../util/';

const state = {
    products: [],
};
const getters = {
    getproducts: function() {
        return state.products;
    }
};
const actions = {
    getproductsAction({commit}) {
        return new Promise((resolve, reject) => {
            makeRequest('/products', {})
            .then((products) => {
                commit('saveproducts', products);
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
    saveproducts(state, products) {
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
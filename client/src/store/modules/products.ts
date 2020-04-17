import {request, RequestMethod} from '../../util';

const state = {
    products: [],
    packSizes: [],
};
const getters = {
    getProducts: function() {
        return state.products;
    },
    getPackSizes: function() {
        return state.packSizes;
    }
};
const actions = {
    getProductsAction({commit}, {categoryId, subcategoryId}) {
        let url = '/api/products?';
        url += categoryId ? 'categoryId=' + categoryId : '';
        url += subcategoryId ? '&subcategoryId=' + subcategoryId : '';

        return new Promise((resolve, reject) => {
            request.make(url, {})
            .then((response) => {
                commit('addProducts', response.products);
                resolve(response.products);
            })
            .catch((err) => {
                console.log(err);
                reject();
            });
        });
    },
    addProductAction({commit}, product) {
        return new Promise((resolve, reject) => {
            request.make('/api/products', product, RequestMethod.POST)
            .then((response) => {
                resolve(response);
            })
            .catch((err) => {
                reject();
            });
        });
    },
    getPackSizesAction({commit}, product) {
        return new Promise((resolve, reject) => {
            request.make('/api/products/pack', {}, RequestMethod.GET)
            .then((response) => {
                commit('addPackSizes', response.packSizes)
                resolve(response.packSizes);
            })
            .catch((err) => {
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
    },
    addPackSizes(state, packSizes) {
        state.packSizes = packSizes;
    }
};

export default {
    namespaced: true,
    state,
    getters,
    actions,
    mutations,
};
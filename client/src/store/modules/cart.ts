import {request, RequestMethod} from '../../util';

const state = {
    products: [],
}

const getters = {
    getProducts: function() {
        return state.products;
    }
};
const actions = {
    initCartAction({commit}) {
        return new Promise((resolve) => {
            //localStorage.getItem('')
            //commit('addProducts', products);
            resolve();
        });
    },
    addProductAction({commit}, product) {
        return new Promise((resolve) => {
            commit('addProduct', product);
            resolve();
        });
    },
    removeProductAction({commit}, productId) {
        return new Promise((resolve) => {
            commit('removeProduct', productId);
            resolve();
        });
    },
    emptyCartAction({commit}) {
        return new Promise((resolve) => {
            commit('removeAllProduct');
            resolve();
        });
    },
    makeOrderAction({commit, state, dispatch}){
        const order = state.products.map(x => ({id: x.id, quantity: x.quantity}));
        return new Promise((resolve, reject) => {
            request.make('/api/orders', order, RequestMethod.POST)
            .then(() => {
                commit('removeAllProduct');
                dispatch('orders/getOrdersAction', {}, {root: true})
                resolve();
            })
            .catch((err) => {
                console.log(err);
                reject();
            });
        });
    }
};

const mutations = {
    addProduct(state, product) {
        const _product = state.products.find(p => p.id === product.id);
        if(_product) {
            _product.quantity += product.quantity; 
        }
        else {
            state.products.push(product);
        }
    },
    removeProduct(state, productId) {
        state.products = state.products.filter(p => p.id != productId); 
    },
    removeAllProduct(state) {
        state.products = [];
    }
};


export default {
    namespaced: true,
    state,
    getters,
    actions,
    mutations,
};
import {makeRequest, RequestMethod} from '../../util';

const state = {
    orders: [],
    currentOrder: [],
}

const getters = {
    getOrders: function() {
        return state.orders;
    },
    getCurrentOrder: function() {
        return state.currentOrder;
    }
};
const actions = {
    getOrdersAction({commit, state}){
        return new Promise((resolve, reject) => {
            makeRequest('/api/orders', {}, RequestMethod.GET)
            .then((response) => {
                commit('addOrders', response.orders);
                resolve();
            })
            .catch((err) => {
                console.log(err);
                reject();
            });
        });
    },
    getOrderAction({commit, state}, id) {
        return new Promise((resolve, reject) => {
            makeRequest(`/api/orders/${id}`, {}, RequestMethod.GET)
            .then((response) => {
                commit('setCurrentOrder', response);
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
    addOrders(state, orders) {
        state.orders = orders;
    },
    setCurrentOrder(state, order) {
        state.currentOrder = order;
    }
};


export default {
    namespaced: true,
    state,
    getters,
    actions,
    mutations,
};
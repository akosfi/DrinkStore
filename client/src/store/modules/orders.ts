import {request, RequestMethod} from '../../util';

const state = {
    orders: [],
    currentOrder: null,
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
    getOrdersAction({commit}){
        return new Promise((resolve, reject) => {
            request.make('/api/orders', {}, RequestMethod.GET)
            .then((response) => {
                commit('addOrders', response.orders);
                resolve();
            })
            .catch((err) => {
                reject();
            });
        });
    },
    getOrderAction({commit}, id) {
        return new Promise((resolve, reject) => {
            request.make(`/api/orders/${id}`, {}, RequestMethod.GET)
            .then((response) => {
                commit('setCurrentOrder', response);
                resolve();
            })
            .catch((err) => {
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
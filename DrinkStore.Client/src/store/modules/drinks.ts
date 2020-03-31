import {makeRequest} from '../../util/';

const state = {
    drinks: [],
};
const getters = {
    getDrinks: function() {
        return state.drinks;
    }
};
const actions = {
    getDrinksAction({commit}) {
        return new Promise((resolve, reject) => {
            makeRequest('/drinks', {})
            .then((drinks) => {
                commit('saveDrinks', drinks);
            })
            .catch();
        });
    }
};

const mutations = {
    saveDrinks(state, drinks) {
        state.drinks = drinks;
    }
};

export default {
    namespaced: true,
    state,
    getters,
    actions,
    mutations,
};
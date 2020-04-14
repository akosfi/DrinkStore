import {makeRequest} from '../../util';

const state = {
    categories: [],
    selected: 0,
};

const getters = {
    getCategories: function() {
        return state.categories;
    },
    getSelectedCategory: function() {
        return state.selected;
    },
};
const actions = {
    getCategoriesAction({commit}) {
        return new Promise((resolve, reject) => {
            makeRequest('/api/categories', {})
            .then((categories) => {
                commit('addCategories', categories);
                resolve(categories);
            })
            .catch((err) => {
                console.log(err);
                reject();
            });
        });
    }
};

const mutations = {
    addCategories(state, categories) {
        state.categories = categories;
    },
    setSelectedCategory(state, selectedId) {
        state.selected = selectedId;
    }
};

export default {
    namespaced: true,
    state,
    getters,
    actions,
    mutations,
};
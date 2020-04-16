import {makeRequest} from '../../util';

const state = {
    categories: [],
    selected: 0,
    subSelected: 0,
};

const getters = {
    getCategories: function() {
        return state.categories;
    },
    getSelectedCategory: function() {
        return state.selected;
    },
    getSelectedSubCategory: function() {
        return state.subSelected;
    },
};
const actions = {
    getCategoriesAction({commit}) {
        return new Promise((resolve, reject) => {
            makeRequest('/api/categories', {})
            .then((data) => {
                commit('addCategories', data.categories);
                resolve(data.categories);
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
    },
    setSelectedSubCategory(state, selectedId) {
        state.subSelected = selectedId;
    }
};

export default {
    namespaced: true,
    state,
    getters,
    actions,
    mutations,
};
import {request} from '../../util';

const state = {
    categories: [] as Array<{id}>,
    selected: 0,
    subSelected: 0,
};

const getters = {
    getCategories: function() {
        return state.categories;
    },
    getSubcategories: state => function(id) {
        return state.categories.find(c => c.id == id)?.subcategories;
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
            request.make('/api/categories', {})
            .then((data) => {
                commit('addCategories', data.categories);
                resolve(data.categories);
            })
            .catch((err) => {
                console.log(err);
                reject();
            });
        });
    },
    setSelectedCategoryAction({commit}, id) {
        return new Promise((resolve) => {
            commit('setSelectedCategory', id);
            resolve();
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
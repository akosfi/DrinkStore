import Vue from 'vue';
import Vuex from 'vuex';

import drinks from './modules/drinks';

Vue.use(Vuex);

export default new Vuex.Store({
    modules: {
        drinks,
    },
    strict: true,
});
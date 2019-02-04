import Vue from 'vue';
import Vuex from 'vuex';
Vue.use(Vuex);

import BookStore from './bookStore';
import AccountStore from './accountStore';

export default new Vuex.Store({
    state: {
        errors: []
    },
    mutations: {
        addError(state, error) {
            state.errors.splice(0);
            state.errors.push(error);
        },
        clearErrors(state) {
            state.errors.splice(0);
        }
    },
    modules: {
        books: BookStore,
        account: AccountStore
    }
});
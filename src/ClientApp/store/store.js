import Vue from 'vue';
import Vuex from 'vuex';
Vue.use(Vuex);

import AccountStore from './accountStore';
import TodoStore from './todoStore';

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
        account: AccountStore,
        todos: TodoStore,
    }
});

import { VueInstance, Errors } from '../app';
import Router from '../router';

export default {
    namespaced: true,
    state: {
        token: null
    },
    getters: {
        isLoggedIn: state => {
            if (state.token)
                return true;
            else
                return false;
        },
        getAuthorizationHeader: state => {
            if (state.token)
                return 'Bearer ' + state.token;
            else
                return null;
        }
    },
    mutations: {
        set(state, token) {
            state.token = token;
            VueInstance.axios.defaults.headers.common['Authorization'] = 'Bearer ' + state.token;
        },
        clear(state) {
            state.token = null;
            VueInstance.axios.defaults.headers.common['Authorization'] = null;
        }
    },
    actions: {
        login(context, user) {
            VueInstance.axios.post('/account/generatetoken', user)
                .then(response => {
                    if (response.data.token) {
                        context.commit('set', response.data.token);
                        Router.push('/');
                    }
                }).catch(e => {
                    // VueInstance.errors.length = 0;
                    context.commit('addError', e, {root: true});
                });
        },
        register(context, user) {
            VueInstance.axios.post('/account/register', user)
            .then(response => {
                if (response.data.token) {
                    context.commit('set', response.data.token);
                    Router.push('/');
                }
            }).catch(e => {
                // VueInstance.errors.length = 0;
                context.commit('addError', e, {root: true});
            });
        },
        logout(context) {
            context.commit('clear');
            Router.push('/');
        }
    }
}
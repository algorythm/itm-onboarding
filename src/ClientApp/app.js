import './css/site.css';
import 'bootstrap';

import Vue from 'vue';
Vue.config.devtools = true;

// Axios
import Axios from 'axios';
import VueAxios from 'vue-axios';
Vue.use(VueAxios, Axios);

// Router
import VueRouter from 'vue-router';
Vue.use(VueRouter);
Vue.use(require('vue-moment'));

import Router from './router';
import Store from './store/store'
import App from './components/App.vue';

// Clear errors when navigating to new page
Router.beforeEach((to, from, next) => {
    if (Store.state.errors.length > 0) {
        Store.commit('clearErrors');
    }
    next();
 });

export const VueInstance = new Vue({
    el: '#app-root',
    router: Router,
    render: h => h(App),
    store: Store
});
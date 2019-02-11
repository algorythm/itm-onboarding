import VueRouter from 'vue-router';

import Home from './components/Home.vue';
import Counter from './components/Examples/Counter.vue';
import FetchData from './components/Examples/FetchData.vue';
import Books from './components/Books/Books.vue';
import Register from './components/Account/Register.vue';
import Login from './components/Account/Login.vue';
import Todos from './components/Todos/Todos.vue';

export default new VueRouter({
    mode: 'history',
    routes: [
        { path: '/', component: Home },
        { path: '/counter', component: Counter },
        { path: '/fetchdata', component: FetchData },
        { path: '/books', component: Books },
        { path: '/todos', component: Todos },
        { path: '/register', component: Register },
        { path: '/login', component: Login }
    ]
});


import VueRouter from 'vue-router';

import Home from './components/Home.vue';
import Register from './components/Account/Register.vue';
import Login from './components/Account/Login.vue';
import Todos from './components/Todos/Todos.vue';

export default new VueRouter({
    mode: 'history',
    routes: [
        { path: '/', component: Home },
        { path: '/todos', component: Todos },
        { path: '/register', component: Register },
        { path: '/login', component: Login }
    ]
});

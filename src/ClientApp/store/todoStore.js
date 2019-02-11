import { VueInstance } from '../app';

export default {
    namespaced: true,
    modules: {
    },

    state: {
        todos: []
    },
    getters: {

    },
    mutations: {
        set(state, todos) {
            state.todos = todos;
        },
        add(state, todo) {
            state.todos.push(todo)
        }
    },
    actions: {
        refresh(context) {
            VueInstance.axios.get('/api/todo/').then(response => {
                context.commit('set', response.data);
             });
        },
        add(context, todo) {
            VueInstance.axios({
                method: 'post',
                url: '/api/todo',
                data: todo
            }).then(response => {
                context.commit('add', todo);
            });
        }

    }

}
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
        },
        // remove(state, todo) {
        //     state.todos = state.todos.filter(item => item.id != todo.id);
        // },
        complete(state, todo) {
            state.todos[state.todos.indexOf(todo)].completed = true;
        }
    },
    actions: {
        refresh(context) {
            VueInstance.axios.get('/api/todo/').then(response => {
                context.commit('set', response.data);
             });
        },
        add(context, todo) {
            VueInstance.axios.push('/api/todo/', todo).then(response => {
                context.commit('add', response.data);
            });
        },
        remove(context, todo) {
            VueInstance.axios.delete(`/api/todo/${todo.id}`).then(response => {
                context.dispatch('refresh');
            });
        },
        complete(context, todo) {
            VueInstance.axios.patch(`/api/todo/${todo.id}/complete`).then(response => {
                context.commit('complete', todo);
            });
        },
    }

}
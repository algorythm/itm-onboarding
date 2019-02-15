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
            VueInstance.axios.post('/api/todo/', todo).then(response => {
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
        update(context, todo) {
            VueInstance.axios.put(`/api/todo/${todo.id}`, todo).then(response => {
                context.dispatch('refresh');
            });
        },
        move(context, move) {
            VueInstance.axios.post(`/api/todo/move/${move.element.id}`, move).then(response => {
                context.dispatch('refresh');
            });
        },
    },
}
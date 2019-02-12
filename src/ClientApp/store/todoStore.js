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
        remove(state, todo) {
            state.todos = state.todos.filter(item => item.id != todo.id);
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
            console.log(`will remove todo ${todo.id}`);
            VueInstance.axios.delete(`/api/todo/${todo.id}`).then(response => {
                console.log("Deleted todo");
                context.dispatch('refresh');
            });
        }

    }

}
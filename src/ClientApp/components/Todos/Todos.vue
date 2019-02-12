<template>
<div>
    <h1>Todos</h1>
    <div class="loading" v-if="todos.length === 0">Loading todos...</div>
    <div class="todobox" v-if="todos.length > 0">
        <div class="todo-list">
            <div v-for="todo in todos" :key="todo.id">
                <TodoListItem :todo="todo" />
            </div>
        </div>
    </div>

    <br>

    <form v-on:submit.prevent>
        <input v-model="newTodoTitle" />
        <input type="submit" @click="addTodo" value="Add">
    </form>
</div>
</template>

<script>
import TodoListItem from './TodoListItem.vue';

export default {
    mounted() {
        this.$store.dispatch("todos/refresh");
    },
    computed: {
        todos() {
            return this.$store.state.todos.todos;
        },
        newTodoItem() {
            return { title: this.newTodoTitle, completed: false, };
        }
    },
    components: {
        TodoListItem: TodoListItem
    },
    methods: {
        refreshTodos() {
            this.$store.dispatch("todos/refresh");
        },
        addTodo() {
            this.$store.dispatch("todos/add", this.newTodoItem);
            this.newTodoTitle = "";
        },
    },
    data() {
        return {
            newTodoTitle: "",
        };
    }
}
</script>

<style scoped>
.todobox {
    min-width: 500px;
    padding: 12px 0;

    background: #fff;
    border-radius: 2px;
    display: inline-block;
    margin: 1rem;
    position: relative;

    box-shadow: 0 1px 3px rgba(0,0,0,0.12), 0 1px 2px rgba(0,0,0,0.24);
    transition: all 0.3s cubic-bezier(.25,.8,.25,1);
}
.todo-list {
    margin: 0;
    padding: 0;
}
</style>


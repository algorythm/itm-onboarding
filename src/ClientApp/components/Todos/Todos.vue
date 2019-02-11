<template>
<div>
    <h1>Todos</h1>
    <div class="loading" v-if="todos.length === 0">Loading todos...</div>
    <div class="todobox" v-if="todos.length > 0">
        <ul class="todo-list">
            <li class="todo-item" v-for="todo in todos" :key="todo.id">
                <p>{{todo.title}}</p>
            </li>
        </ul>
    </div>
</div>
</template>

<script>
export default {
    mounted() {
        this.$store.dispatch("todos/refresh");
    },
    computed: {
        todos() {
            return this.$store.state.todos.todos;
        }
    },
    methods: {
        refreshTodos() {
            this.$store.dispatch("todos/refresh");
        },
        addTodo() {
            this.$store.dispatch("todos/add", todo);
        },
    }
}
</script>

<style scoped>

</style>


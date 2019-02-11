<template>
<div>
    <h1>Todos</h1>
    <div class="loading" v-if="todos.length === 0">Loading todos...</div>
    <div class="todos" v-if="todos.length > 0">
        <ul class="todo-container" v-for="todo in todos" :key="todo.id">
            <li>{{todo.title}}</li>
        </ul>
    </div>
</div>
</template>

<script>
export default {
    data() {
        return {
            todos: []
        }
    },
    mounted() {
        fetch("/api/todo")
            .then(res => res.json())
            .then(data => {
                this.todos = data;
            });
    }
}
</script>

<style scoped>

</style>


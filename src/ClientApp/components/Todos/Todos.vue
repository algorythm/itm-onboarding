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
        console.log("Fetching todos");
        fetch("/api/todo")
            .then(res => res.json())
            .then(data => {
                console.log("DONE!")
                console.log("Loaded todos from API", data);
                this.todos = data;
            });
    }
}
</script>

<style scoped>

</style>


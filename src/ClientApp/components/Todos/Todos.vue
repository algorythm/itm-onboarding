<template>
<div>
    <h1>Todos</h1>
    <div class="loading" v-if="todos.length === 0">Loading todos...</div>
    <div class="todobox" v-if="todos.length > 0">
        <div class="todo-list">
            <div :class="[completedClass(todo), 'todo-item']" v-for="todo in todos" :key="todo.id">
                <p>{{todo.title}} <button style="float: right;" @click="removeTodo(todo)">Remove</button></p>
            </div>
        </div>
    </div>

    <!-- <form>
        <input type="text" v-model="newTodoItem" />
        <input type="submit" value="Create Todo" />
        {{newTodoItem}}
    </form> -->
    <br>
    <form v-on:submit.prevent>
        <!-- <input v-model="newTodoItem.title" /> -->
        <input v-model="newTodoTitle" />
        <input type="submit" @click="addTodo" value="Add">
    </form>
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
        },
        newTodoItem() {
            return { title: this.newTodoTitle, completed: false, };
        }
    },
    methods: {
        refreshTodos() {
            this.$store.dispatch("todos/refresh");
        },
        addTodo() {
            this.$store.dispatch("todos/add", this.newTodoItem);
            this.newTodoTitle = "";
        },
        removeTodo(todo) {
            this.$store.dispatch("todos/remove", todo);
        },
        completedClass(todo) {
            return todo.completed ? "todo-completed" : "";
        }
    },
    data() {
        return {
            // newTodoItem: { title: "", completed: false },
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

.todo-item {
    margin: 0;
    position: table-cell;
    vertical-align: middle;
}

.todo-item:hover {
    background-color: rgba(0, 0, 0, .12);
}

.todo-item p {
    margin: auto;
    padding: 16px;
    display: inline-flex;
}

.todo-item p button {
    align-self: stretch;
}

.todo-item::after {
    content: "";
    display: block;
    border-top: solid 1px rgba(0, 0, 0, .12);
    padding: 0 !important;
    margin: 0;
}

.todo-list {
    margin: 0;
    padding: 0;
}

.todo-completed {
    text-decoration: line-through;
    color: rgba(0, 0, 0, .54);
}
</style>


<template>
  <div>
    <h1>Todos</h1>
    <div class="loading" v-if="todos.length === 0">No todos have been added.</div>
    <div class="todobox" v-if="todos.length > 0">
      <div class="todo-list">
        <div v-for="todo in todos" :key="todo.id">
          <TodoListItem :todo="todo"/>
        </div>
      </div>
    </div>
    <TodoCreateForm/>

    <br>

  </div>
</template>

<script>
import TodoListItem from "./TodoListItem.vue";
import TodoCreateForm from "./TodoCreateForm.vue";

export default {
  mounted() {
    this.$store.dispatch("todos/refresh");
  },
  computed: {
    todos() {
      return this.$store.state.todos.todos;
    }
  },
  components: {
    TodoListItem: TodoListItem,
    TodoCreateForm: TodoCreateForm
  },
  methods: {
    refreshTodos() {
      this.$store.dispatch("todos/refresh");
    }
  }
};
</script>

<style scoped>
.todobox {
  min-width: 500px;
  background: #fff;
  border-radius: 2px;
  display: inline-block;
  margin: 1rem;
  position: relative;

  box-shadow: 0 1px 3px rgba(0, 0, 0, 0.12), 0 1px 2px rgba(0, 0, 0, 0.24);
  transition: all 0.3s cubic-bezier(0.25, 0.8, 0.25, 1);
}
.todo-list {
  margin: 0;
  padding: 0;
}
</style>

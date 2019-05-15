<template>
  <div>
    <h1>Todos {{time}}</h1>
    <hr>
    <div class="loading" v-if="todos.length === 0">No todos have been added.</div>
    <div class="todo-container">

      <div class="todobox" v-if="todos.length > 0">
        <div class="todo-list">
          <draggable v-model="todos" :list="todos" @change="orderChanged">
            <div v-for="todo in todos" :key="todo.id">
              <TodoListItem :todo="todo"/>
            </div>
          </draggable>
        </div>
      </div>
      <TodoCreateForm/>
    </div>
  </div>
</template>

<script>
import TodoListItem from "./TodoListItem.vue";
import TodoCreateForm from "./TodoCreateForm.vue";
import draggable from "vuedraggable";

export default {
  mounted() {
    this.$store.dispatch("todos/refresh");
    this.todoList = this.$store.state.todos.todos;
  },
  data() {
    return {
      todoList: []
    };
  },
  computed: {
    todos() {
      return this.$store.state.todos.todos;
    },
    time() {
      return Date.now();
    }
  },
  components: {
    TodoListItem: TodoListItem,
    TodoCreateForm: TodoCreateForm,
    draggable
  },
  methods: {
    refreshTodos() {
      this.$store.dispatch("todos/refresh");
    },
    orderChanged(obj) {
      this.$store.dispatch("todos/move", obj.moved);
    },
  }
};
</script>

<style scoped>
.todobox {
  /* min-width: 500px; */
  width: 100%;
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

<template>
  <div class="todo-item" :class="completedClass(todo)">
    <div class="content">
      <!-- <p class="title">{{todo.title}}</p> -->
      <TodoTitle class="todo-title" :todo="todo" />
      <!-- <p class="subtitle">Subtitle</p> -->
    </div>
    <div class="button-group">
      <button class="check" v-if="!todo.completed" @click="completeTodo(todo)">
        <span class="glyphicon glyphicon-check"></span>
      </button>
      <button class="remove" @click="removeTodo(todo)">
        <span class="glyphicon glyphicon-trash"></span>
      </button>
    </div>
  </div>
</template>

<script>
import TodoTitle from './TodoTitle.vue';

export default {
  props: ["todo"],
  methods: {
    removeTodo(todo) {
      this.$store.dispatch("todos/remove", todo);
    },
    completedClass(todo) {
      return todo.completed ? "todo-item-completed" : "";
    },
    completeTodo(todo) {
      this.$store.dispatch("todos/complete", todo);
    }
  },
  computed: {
    todos() {
      return this.$store.state.todos.todos;
    },
    newTodoItem() {
      return { title: this.newTodoTitle, completed: false };
    }
  },
  components: {
    TodoTitle: TodoTitle
  },
  data() {
    return {
      newTodoTitle: ""
    };
  }
};
</script>

<!-- TODO: Why can't this style tag be scoped?? -->
<!-- When it's scoped, the button gets placed on the next line -->
<style>
.todo-item {
  display: flex;
  justify-content: space-between;
  align-items: center;
  border-bottom: solid 1px rgba(0, 0, 0, 0.12);
}

.todo-item .content {
  margin: 8px 16px;
}

.todo-item .button-group {
  margin-right: 16px;
}

.todo-item p {
  margin: 0;
}

/* .todo-item p.title {
  font-size: 14pt;
} */
.todo-item p.subtitle {
  font-size: 9pt;
}

.todo-item:hover {
  background-color: rgba(0, 0, 0, 0.12);
}

.todo-item .button-group button {
  background-color: transparent;
  border: none;
}

.todo-item .button-group .remove {
  color: #dc3545;
}
.todo-item .button-group .check {
  color: #28a745;
}

.todo-item-completed {
  color: rgba(0, 0, 0, 0.54);
}

.todo-item-completed p.title {
  text-decoration: line-through;
}
</style>

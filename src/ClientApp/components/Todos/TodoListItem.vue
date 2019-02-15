<template>
  <div class="todo-item" :class="completedClass(todo)">
    <div class="content">
      <TodoTitle class="todo-title" :todo="todo" />
      <p class="subtitle" v-if="todo.dateExpired != null && todo.completed == false">
        <span class="todoStatus badge" :class="expirationStatusClass" v-if="expirationStatus != null">{{expirationStatus}}</span>
        Expires: {{ todo.dateExpired | moment("dddd, MMM Do YYYY, HH:mm") }}
      </p>
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
    },
    expirationStatus() {
      const exp = new Date(this.todo.dateExpired);
      const now = new Date();

      const timeDiffSeconds = (exp.getTime() - now.getTime()) / 1000;
      const daysLeft = timeDiffSeconds / 86400;

      if (daysLeft < 0) {
        return this.overdueText;
      } else if (daysLeft < 1) {
        return this.todayText;
      } else if (daysLeft < 2) {
        return this.tomorrowText;
      } else if (daysLeft < 7) {
        return this.weekText;
      }

      return this.inAWhileText;
    },
    expirationStatusClass() {
      if (this.expirationStatus === this.overdueText) {
        return "badge-secondary";
      } else if (this.expirationStatus === this.todayText) {
        return "badge-danger";
      } else if (this.expirationStatus === this.tomorrowText) {
        return "badge-warning";
      } else if (this.expirationStatus === this.weekText) {
        return "badge-warning";
      }

      return "badge-success";
    }
  },
  components: {
    TodoTitle: TodoTitle
  },
  data() {
    return {
      newTodoTitle: "",
      overdueText: "overdue",
      todayText: "< 1 day",
      tomorrowText: "tomorrow",
      weekText: "within a week",
      inAWhileText: "the future"
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

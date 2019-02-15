<template>
  <div id="todo-creation-form">
    <form v-on:submit.prevent>
      <div class="form-group">
        <input v-model="newTodoTitle" class="form-control" aria-describedby="titleHelp" placeholder="Remember to empty the dishwasher">
        <date-picker v-model="date" :config="options" placeholder="Expiration date"></date-picker>
        <button @click="addTodo" class="btn btn-primary">
            <span class="glyphicon glyphicon-plus"></span>
        </button>
      </div>
      <div class="form-group">
        <small class="form-text text-muted" id="titleHelp">This is the title of the new todo item.</small>
      </div>
    </form>
  </div>
</template>

<script>
import datePicker from 'vue-bootstrap-datetimepicker';
import 'pc-bootstrap4-datetimepicker/build/css/bootstrap-datetimepicker.css';

export default {
  data() {
    return {
      newTodoTitle: "",
      date: null,
      options: {
        // format: "dddd, MMM Do YYYY, HH:mm",
        format: "YYYY-MM-DDTHH:mm:ss",
        useCurrent: false,
      }
    };
  },
  methods: {
    addTodo() {
      this.$store.dispatch("todos/add", this.newTodoItem);
      this.newTodoTitle = "";
    }
  },
  computed: {
    newTodoItem() {
      return { title: this.newTodoTitle, completed: false, dateExpired: this.date };
    }
  },
  components: {
    datePicker,
  },
};
</script>

<style>
.form-group {
    display: flex;
    margin: 8px;
}

.form-group input {
    margin-right: 4px;
}

.form-group button {
    margin-left: 4px;
}

#todo-creation-form {
    padding: 8px;
    background-color: rgba(0, 0, 0, 0.12);
}
</style>


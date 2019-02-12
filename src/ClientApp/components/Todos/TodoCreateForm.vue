<template>
  <div id="todo-creation-form">
    <form v-on:submit.prevent>
      <div class="form-group">
        <input v-model="newTodoTitle" class="form-control" aria-describedby="titleHelp" placeholder="Remember to empty the dishwasher">
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
export default {
  data() {
    return {
      newTodoTitle: ""
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
      return { title: this.newTodoTitle, completed: false };
    }
  }
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


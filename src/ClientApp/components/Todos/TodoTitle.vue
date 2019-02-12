<template>
  <div class="title-wrapper">
    <div class="edit-mode" v-if="editMode && !todo.completed">
      <form v-on:submit.prevent class="form-inline">
        <input type="text" class="form-control" v-model="todo.title">
        <button class="btn btn-success" @click="saveChanges">Save</button>
        <button class="btn btn-secondary" @click="toggleEditMode">
          <span class="glyphicon glyphicon-remove"></span>
        </button>
      </form>
    </div>
    <div class="edit-mode" v-else-if="editMode && todo.completed">
      <button class="btn btn-secondary" @click="toggleEditMode">
        <span class="glyphicon glyphicon-remove"></span>
      </button>
      <button class="btn btn-warning" @click="markUnfinished">Mark as unfinished</button>
      <p class="title" style="display: inline;">{{todo.title}}</p>
    </div>
    <div class="show-mode mode-title" v-else>
      <p class="title" @click="toggleEditMode">{{todo.title}}</p>
    </div>
  </div>
</template>

<script>
export default {
  props: ["todo"],
  data() {
    return {
      editMode: false
    };
  },
  methods: {
    toggleEditMode() {
      this.editMode = !this.editMode;
    },
    saveChanges() {
      console.log("save changed", this.todo);
      this.$store.dispatch("todos/update", this.todo);
      this.editMode = false;
    },
    markUnfinished() {
      console.log("mark unfinished");
      this.todo.completed = false;
      this.saveChanges();
    }
  }
};
</script>


<style>
p.title {
  font-size: 14pt;
}
.edit-mode input {
  width: 300px;
}
.title-wrapper {
  cursor: pointer;
}
</style>

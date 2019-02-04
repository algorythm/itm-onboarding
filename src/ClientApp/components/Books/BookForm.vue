<template>
    <div>
        <input v-model="title"></input>
        <button v-on:click="submit()">Add</button>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                title: ''
            }
        },

        methods: {
            submit() {
                this.$store.dispatch('books/add', this.getBook());
                this.title = '';
            },

            getBook() {
                var number = this.$store.getters.getNextBookNumber;
                return {title: this.title, number: number};
            }
        }
    }
</script>
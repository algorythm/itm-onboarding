<template>
    <ol>
        <li v-for="favorite in favorites" class="book-favorite"><span>{{favorite.title}}</span></li>
    </ol>
</template>

<script>
    export default {
        data() {
            return {
                favorites: this.$store.state.books.favorites
            }
        },

        mounted() {
        }
    }
</script>

<style>

</style>
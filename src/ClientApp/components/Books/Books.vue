<template>
    <div>
        <h1>Books</h1>
        <table v-if="books.length" class="table">
            <thead>
                <tr>
                    <th>Number</th>
                    <th>Title</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="book in books">
                    <td>{{book.number}}</td>
                    <td>{{book.title}}</td>
                    <button v-on:click="addFavorite(book)">Add to favorites</button>
                    <button v-on:click="deleteBook(book)">Delete</button>
                </tr>
            </tbody>
        </table>
        <button v-on:click="refreshBooks()">Refresh</button>

        <br/>
        <bookform></bookform>

        <documentfavorites></documentfavorites>
    </div>
</template>

<script>
    import BookFavorites from './BookFavorites.vue';
    import BookForm from './BookForm.vue';

    export default {
        components: {
            documentfavorites: BookFavorites,
            bookform: BookForm
        },

        mounted() {
            this.$store.dispatch("books/refresh");
        },

        computed: {
            books() {
                return this.$store.state.books.books;
            }
        },

        methods: {
            refreshBooks() {
                this.$store.dispatch("books/refresh");
            },
            addFavorite(book) {
                this.$store.commit("books/addFavorite", book);
            },
            deleteBook(book) {
                this.$store.dispatch("books/delete", book);
            },
            addBook(book) {
                this.$store.dispatch("books/add", book);
            }
        }
    }
</script>
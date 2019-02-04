import { VueInstance } from '../app';

export default {
    namespaced: true,
    modules: {
    },
    state: {
        books: [],
        favorites: [{ title: 'test favorite' }]
    },
    getters: {
        getNextBookNumber: state => {
            let max = 0;
            const books = state.books;

            for(let i = 0; i < books.length; i++) {
                const bookNumber = books[i].number;
                if (max < bookNumber) {
                    max = bookNumber + 1;
                }
            }
            return max;
        }
    },
    mutations: {
        set(state, books) {
            state.books = books;
        },
        add(state, book) {
            state.books.push(book);
        },
        addFavorite(state, book) {
            state.favorites.push(book);
        }
    }, 
    actions: {
        refresh(context) {
            VueInstance.axios.get('/api/document/').then(response => {
                context.commit('set', response.data);
            });
        },
        add(context, book) {
            //DocumentResource.save(book).then( response => {
            //    context.commit('add', book);
            //});
        },
        delete(context, book) {
            //DocumentResource.delete({id: book.number}).then(response => {
            //    context.dispatch('refresh');
            //});
        }
    }
}
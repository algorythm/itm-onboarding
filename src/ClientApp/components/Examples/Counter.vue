<template>
    <div>
        <h1>Counter 2</h1>

        <p>This is a simple example of a Vue.js component.</p>

        <p>Current count: <strong>{{ currentcount }}</strong></p>

        <button @click="incrementCounter">Increment</button>

        <CounterItem title="helo"></CounterItem>
        <CounterItem title="helo"></CounterItem>
        <CounterItem title="123"></CounterItem>
    </div>
</template>


<script>
    import CounterItem from './CounterItem.vue';

    export default {
        components: {
            CounterItem: CounterItem
        },

        data() {
            return {
                currentcount: 4
            }
        },

        methods: {
            incrementCounter() {
                this.currentcount += 2;
            }
        }
    }

</script>

<style></style>
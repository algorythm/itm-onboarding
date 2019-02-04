<template>
    <div id='app-root' class="container-fluid">
        <div class="row">
            <div class="col-sm-3">
                <menucomponent />
            </div>
            <div class="col-sm-9">
                <div v-for="error in this.$store.state.errors">
                    {{error.response.data}}
                </div>
                <router-view></router-view>
            </div>
        </div>
    </div>
</template>

<script>
    import NavMenu from './NavMenu.vue';

    export default {
        components: {
            menucomponent: NavMenu
        }
    }
</script>
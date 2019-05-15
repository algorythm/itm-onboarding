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
                <router-view style="margin-right: 30px"></router-view>
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

<style>
.btn-primary {
    background-color: #007bff;
    border-color: #007bff;
}

.btn-secondary {
    color: #fff;
    background-color: #6c757d;
    border-color: #6c757d;
}

.btn-info {
    background-color: #17a2b8;
    border-color: #17a2b8;
}
</style>
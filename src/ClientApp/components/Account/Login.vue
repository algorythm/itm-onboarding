<template>
    <div class="form-horizontal">
        <h4>Use a local account to log in.</h4>
        <hr />
        <div asp-validation-summary="All" class="text-danger"></div>
        <div class="form-group">
            <label class="col-md-2 control-label">Email</label>
            <div class="col-md-10">
                <input v-model="email" id="Email" name="Email" class="form-control" type="email" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-md-2 control-label">Password</label>
            <div class="col-md-10">
                <input v-model="password" id="Password" name="Password" class="form-control" type="password" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <div class="checkbox">
                    <label>
                        Remeber me
                        <input id="RememberMe" type="checkbox" />
                    </label>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <button @click="login" class="btn btn-default">Log in</button>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                email: '',
                password: ''
            }
        },
        methods: {
            login() {
                this.$store.dispatch('account/login',
                    { email: this.email, password: this.password });
            }
        }
    }
</script>
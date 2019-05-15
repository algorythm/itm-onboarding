<template>
    <div class="form-horizontal">
        <h4>Use a local account to log in. {{time}}</h4>
        <hr />
        <div asp-validation-summary="All" class="text-danger"></div>
        <div class="form-group">
            <label class="col-md-2 control-label">Email</label>
            <div class="col-md-10">
                <input v-model="email" id="Email" name="Email" class="form-control" type="email" placeholder="john.doe@example.com" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-md-2 control-label">Password</label>
            <div class="col-md-10">
                <input v-model="password" id="Password" name="Password" class="form-control" type="password" placeholder="MyÜber_S3CUreP4zzw0!d" />
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
        computed: {
            time() {
                return Date.now();
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
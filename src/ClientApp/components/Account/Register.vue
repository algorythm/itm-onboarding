<template>
    <div class="form-horizontal">
        <h4>Create a new account.</h4>
        <hr />
        <div asp-validation-summary="All" class="text-danger"></div>
        <div class="form-group">
            <label class="col-md-2 control-label">Email</label>
            <div class="col-md-10">
                <input v-model="email" id="Email" name="Email" class="form-control" type="email" placeholder="john.doe@example.com" />
                <span asp-validation-for="Email" class="text-danger"></span>
            </div>
        </div>
        <div class="form-group">
            <label class="col-md-2 control-label">Password</label>
            <div class="col-md-10">
                <input v-model="password" id="Password" name="Password" class="form-control" type="password" placeholder="MyÜber_S3CUreP4zzw0!d" />
                <span asp-validation-for="Password" class="text-danger"></span>
            </div>
        </div>
        <div class="form-group">
            <label class="col-md-2 control-label">Confirm password</label>
            <div class="col-md-10">
                <input v-model="confirmPassword" id="ConfirmPassword" name="ConfirmPassword" class="form-control" type="password" placeholder="MyÜber_S3CUreP4zzw0!d" />
                <span asp-validation-for="ConfirmPassword" class="text-danger"></span>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <button @click="register" class="btn btn-default">Register</button>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                email: '',
                password: '',
                confirmPassword: ''
            }
        },

        methods: {
            register() {
                this.$store.dispatch('account/register',
                    { email: this.email, 
                    password: this.password, 
                    confirmPassword: this.confirmPassword
                    }
                );
            }
        }
    }
</script>

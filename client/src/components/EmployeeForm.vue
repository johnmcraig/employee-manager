<template>
    <div id="employee-form">
        <form @submit.prevent="handleSubmit">
            <label>Employee name</label>
            <input v-model="employee.name" type="text" />
            <label>Employee email</label>
            <input v-model="employee.email" type="text" />
            <button>Add Employee</button>
        </form>
    </div>
</template>

<script>
 export default {
    name: 'employee-form',
    data () {
        return {
            employee: '',
            email: ''
        }
    },
    methods: {
        handleSubmit() {
            this.$emit('add:employee', this.employee)
        }
    }        
}
</script>

<style scoped>
form {
    margin-bottom: 2rem;
}

</style>
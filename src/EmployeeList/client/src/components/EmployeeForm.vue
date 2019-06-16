<template>
    <div id="employee-form">
        <b-form @submit="onSubmit">
            <b-form-group
                id="input-group-1"
                label="Employee Name:"
                label-for="input-1">
                
                <b-form-input 
                    id="input-1"
                    v-model="employee.name"
                    type="text"
                    required
                    placeholder="Enter name">
                </b-form-input>
                
            </b-form-group>

            <b-form-group
                id="input-group-2"
                label="Employee Email:"
                label-for="input-2">
                
                <b-form-input 
                    id="input-2"
                    v-model="employee.email" 
                    type="text"
                    required
                    placeholder="Enter a valid email">
                </b-form-input>
                
            </b-form-group>

            <b-button type="submit" variant="primary">Add Employee</b-button>
        </b-form>
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
        onSubmit () {
        },
        addEmployee () {

        }
    }        
}
</script>

<style scoped>
form {
    margin-bottom: 2rem;
}
</style>
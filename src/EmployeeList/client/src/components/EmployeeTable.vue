<template>
    <div id="employee-table">
        <table>
            <thead>
                <tr>
                    <th>Employee name</th>
                    <th>Employee email</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="employee in employees" :key="employee.id">
                    <td>{{ employee.name }}</td>
                    <td>{{ employee.email }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import EmployeeService from '@/services/employee-service'

 export default {
    name: 'employee-table',
    data () {
        return {
            employees: []
        }
    },
    created () {
        EmployeeService.getAll().then(response => {
            this.employees = response.data
            console.log(response.data)
        })
        .catch(error => {
            console.log(error)
        })
    }       
}
</script>

<style scoped>

</style>

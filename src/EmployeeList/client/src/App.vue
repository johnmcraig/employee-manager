<template>
  <div id="app" class="small-container">
    <h1>Employees</h1>
    <employee-form @add:employee="addEmployee" />

    <employee-table :employee="employees"/>
  </div>
</template>

<script>
import EmployeeTable from '@/components/EmployeeTable.vue'
import EmployeeForm from '@/components/EmployeeForm.vue'
import EmployeeService from '@/services/employee-service'

export default {
  name: 'app',
  components: {
    EmployeeTable,
    EmployeeForm
  },
  data () {
    return {
    }
  },
  methods: {
    addEmployee(employee) {
      this.employees = [...this.employees, employee]
    }
  }
}
</script>

<style>
button {
  background: #009435;
  border: 1px solid #009435;
}

.small-container {
  max-width: 670px;
}
</style>

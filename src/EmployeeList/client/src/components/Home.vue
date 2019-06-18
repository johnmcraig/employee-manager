<template>
    <div class="small-container">
        <h1 style="text-align:center;">Employees</h1>
        <employee-form />
        <employee-table />
    </div>
</template>

<script>
import EmployeeTable from '@/components/employees/EmployeeTable.vue'
import EmployeeForm from '@/components/employees/EmployeeForm.vue'

export default {
    name: 'Home',
    components: {
      EmployeeTable,
      EmployeeForm
  } 
}
</script>

<style scoped>
.small-container {
  width: 100%;
  max-width: 720px;
  padding: 1rem;
  margin: 2rem;
}
</style>
<template>
  <div id="app" class="small-container">

    <h1 style="text-align:center;">Employees</h1>

    <employee-form />
    <employee-table />

  </div>
</template>

<script>
import EmployeeTable from '@/components/EmployeeTable.vue'
import EmployeeForm from '@/components/EmployeeForm.vue'

export default {
  name: 'app',
  components: {
    EmployeeTable,
    EmployeeForm
  },
  data () {
    return {
      employees: []
    }
  }
}
</script>

<style>
.small-container {
  width: 100%;
  max-width: 720px;
  padding: 1rem;
  margin: 2rem;
}
</style>

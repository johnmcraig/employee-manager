<template>
    <div class="small-container">
        <h1 style="text-align:center;">Employees</h1>
        <employee-form />
    </div>
</template>

<script>
import EmployeeTable from '@/components/EmployeeTable.vue'
import EmployeeForm from '@/components/EmployeeForm.vue'

export default {
    name: 'Home',
    components: {
      EmployeeTable,
      EmployeeForm
  } 
}
</script>

<style lang="scss" scoped>

</style>
<template>
  <!-- <div id="app" class="small-container">
    <h1 style="text-align:center;">Employees</h1>
    <employee-form />
    <employee-table />
    <router-view />
  </div> -->
  <b-container id="app">
    <b-row>
      <b-col>
        <navbar/>
      </b-col>
    </b-row>
    <b-row>
      <b-col>
        <router-view />
      </b-col>
    </b-row>
  </b-container>
</template>

<script>
// import EmployeeTable from '@/components/EmployeeTable.vue'
// import EmployeeForm from '@/components/EmployeeForm.vue'
import Navbar from '@/components/ui/Navbar'

export default {
  name: 'app',
  components: {
    Navbar
  },
  data () {
    return {
      employees: []
    }
  }
}
</script>

<style>
</style>

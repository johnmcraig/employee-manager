<template>
  <div>
    <div class="well">
      <div class="row">
        <div class="col-md-3">
          <strong>Employee Name:</strong>
        </div>
        <div class="col-md-3">
          {{ employee.name }}
        </div>
      </div>
      <div class="row">
        <div class="col-md-3">
          <strong>Employee Email:</strong>
        </div>
        <div class="col-md-3">
          {{ employee.email }}
        </div>
      </div>
    </div>
 
    <div class="row">
      <div class="col-md-12">
        <div class="table-responsive">
          <table class="table table-striped">
            <thead>
              <tr>
                <th>Account type</th>
                <th>Date created</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>Placeholder</td>
                <td>Placeholder</td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import EmployeeService from '@/services/employee-service'

export default {
    name: 'EmployeeDetails',
    data () {
        return {
            employee: {}
        }
    },
    created () {
        EmployeeService.getSingle(this.$router.currentRoute.params.id)
        .then(response => {
        this.owner = response.data
        })
    }  
}
</script>

<style>
</style>

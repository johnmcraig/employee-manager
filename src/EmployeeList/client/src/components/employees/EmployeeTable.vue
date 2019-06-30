<template>
  <div id="employee-table">
    <b-row>
      <b-col
        md="2"
        offset-md="10">
        <router-link :to="{ name: 'EmployeeForm' }">Add Employee</router-link>
      </b-col>
    </b-row>
    <b-row>
      <b-col md="12">
        <div class="table-responsive">
          <table class="table table-striped">
            <thead>
              <tr>
                <th>Employee Name</th>
                <th>Employee Email</th>
                <th>Details</th>
                <th>Update</th>
                <th>Delete</th>
              </tr>
            </thead>
            <tbody>
              <employee-table-row
                v-for="employee in employees"
                :key="employee.id"
                :employee="employee"  
                @details="detailsEmployee"
                @update="updateEmployee"
                @delete="deleteEmployee" />
            </tbody>
          </table>
        </div>
      </b-col>
    </b-row>

    <b-modal
      ref="deleteConfirmModal"
      title="Confirm Deletion!"
      @ok="onDeleteConfirm"
      @hide="onDeleteModalHide">
      <p class="my-4">Are you sure you want to delete this employee?</p>
    </b-modal>
 
    <b-modal
      ref="alertModal"
      :title="alertModalTitle"
      :ok-only="true">
      <p class="my-4">{{ alertModalContent }}</p>
    </b-modal>

  </div>
</template>

<script>
import EmployeeService from '@/services/employee-service'
import EmployeeTableRow from '@/components/employees/EmployeeTableRow'

export default {
  name: 'employee-table',
  components: {
      EmployeeTableRow
  },
  data() {
    return {
      employees: [],
      selectedEmployeeId: null,
      alertModalTitle: '',
      alertModalContent: ''
    }
  },
  created () {
    this.fetchEmployees()
  },
  methods: {
    detailsEmployee(employeeId) {
      this.$router.push({ name: 'EmployeeDetails', params: { id: employeeId } })
      // console.log('details', employeeId)
    },
    updateEmployee(employeeId) {
      this.$router.push({ name: 'EmployeeUpdate', params: { id: employeeId } })
      // console.log('update', employeeId)
    },
    deleteEmployee(employeeId) {
      this.selectedEmployeeId = employeeId
      this.$refs.deleteConfirmModal.show()
      // console.log('delete', employeeId)
    },
    fetchEmployees() {
      EmployeeService.getAll().then(response => {
        this.employees = response.data
      })
    },
    onDeleteConfirm () {
      EmployeeService.delete(this.selectedEmployeeId).then(() => {
        this.alertModalTitle = 'Success!';
        this.alertModalContent = 'Successfully deleted Employee';
        this.$refs.alertModal.show();
        this.fetchEmployees();
      }).catch((error) => {
        this.alertModalTitle = 'Error';
        this.alertModalContent = error.response.data;
        this.$refs.alertModal.show();
      });
    },
    onDeleteModalHide () {
      this.selectedEmployeeId = null;
    }
  }
}
</script>

<style scoped>
</style>

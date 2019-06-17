<template>
  <div id="employee-table">
    <b-row>
      <b-col md="12">
        <div class="table-responsive">
          <table class="table table-striped">
            <thead>
              <tr>
                <th>Employee name</th>
                <th>Employee email</th>
                <th>Details</th>
                <th>Edit</th>
                <th>Delete</th>
              </tr>
            </thead>
            <tbody>
              <employee-table-row
                v-for="employee in employees"
                :key="employee.id"
                :employee="employee"  
                @details="detailsEmployee"
                @edit="editEmployee"
                @delete="deleteEmployee" />
            </tbody>
          </table>
        </div>
      </b-col>
    </b-row>

    <b-modal
      ref="deleteConfirmModal"
      title="Confirm your action"
      @ok="onDeleteConfirm"
      @hide="onDeleteModalHide">
      <p class="my-4">Are you sure you want to delete this owner?</p>
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
        console.log('details', employeeId)
    },
    editEmployee(employeeId) {
        console.log('edit', employeeId)
    },
    deleteEmployee(employeeId) {
        console.log('delete', employeeId)
    //   this.selectedEmployeeId = employeeId
    //   this.$refs.deleteConfirmModal.show()
    },
    fetchEmployees() {
      EmployeeService.getAll().then(response => {
        this.employees = response.data
      })
    },
      onDeleteConfirm () {
      EmployeeService.delete(this.selectedEmployeeId).then(() => {
        this.alertModalTitle = 'Successfully';
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

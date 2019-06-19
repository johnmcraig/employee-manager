<template>
  <tr>
    <td>{{ employee.name }}</td>
    <td>{{ employee.email }}</td>
    <td>
      <b-button variant="secondary" @click="onDetailsClick">Details</b-button>
    </td>
    <td>
      <b-button variant="success" @click="onEditClick">Edit</b-button>
    </td>
    <td>
      <b-button variant="danger" @click="onDeleteClick">Delete</b-button>
    </td>
  </tr>
</template>

<script>
export default {
  name: 'employee-table-row',
  props: [ 'employee' ],
  methods: {
    onDetailsClick() {
        this.$emit('details', this.employee.id)
    },
    onEditClick() {
      this.$emit('edit', this.employee.id)
    },
    onDeleteClick() {
      this.$emit('delete', this.employee.id)
    },
  }
}
</script>

<style>
</style>
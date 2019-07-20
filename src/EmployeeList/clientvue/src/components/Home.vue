<template>
    <div class="container">
        <h2 style="text-align:center;">Welcome to the Employee Entry Form</h2>
        <br />
        <div class="row">
            <div class="col col-lg-12">
                <h3>Add Employees to the Database</h3>
                <p>Navigate to the employee form - <router-link to="/employee/form">Go to Employee Form.</router-link></p>
                <p>Enter form data to add an entry.</p>
            </div>
        </div>

        <div class="row">
            <div class="col col-lg-12">
                <h3>View the Already Existing Employees</h3>
                <p>Navigate to see all current employees - <router-link to="/employee/table">Go to Employee Table.</router-link></p>
                <p>Use the button links on the table to see additional details, edit, or delete an entry.</p>
            </div>
        </div>

    </div>
</template>

<script>
export default {
    name: 'Home',
    components: {
  } 
}
</script>

<style scoped>
.container {
  width: 100%;
  padding: 0.5rem;
  margin: 2rem;
}
</style>
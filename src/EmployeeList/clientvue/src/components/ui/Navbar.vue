<template>
    <b-navbar toggleable="md" type="dark" variant="dark">
        <b-navbar-brand :to="{ name: 'Home' }">Home</b-navbar-brand>
        <b-navbar-nav>
                <b-nav-item :to="{ name: 'EmployeeForm' }">Employee Form</b-nav-item>
                <b-nav-item :to="{ name: 'EmployeeTable' }">Employee Table</b-nav-item>
        </b-navbar-nav>
    </b-navbar>
</template>

<script>
export default {
    name: 'Navbar'
}
</script>

<style>

</style>

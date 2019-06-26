import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '@/components/Home'
import EmployeeDetails from '@/components/employees/EmployeeDetails'
import EmployeeForm from '@/components/employees/EmployeeForm'
import EmployeeTable from '@/components/employees/EmployeeTable'
import EmployeeUpdate from '@/components/employees/EmployeeUpdate'
import NotFound from '@/components/error-pages/NotFound'

Vue.use(VueRouter)

export default new VueRouter({
    mode: 'history',
    routes: [
    { path: '/', name: 'Home', component: Home },
    { path: '/employee/form', name: 'EmployeeForm', component: EmployeeForm },
    { path: '/employee/table', name: 'EmployeeTable', component: EmployeeTable },
    { path: '/employee/:id', name: 'EmployeeDetails', component: EmployeeDetails },
    { path: '/employee/update/:id', name: 'EmployeeUpdate', component: EmployeeUpdate },
    { path: '*', component: NotFound }
  ]
})
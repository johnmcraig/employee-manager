import Vue from 'vue'
import Router from 'vue-router'
import App from './App'
import EmployeeDetails from '@/components/employees/EmployeeDetails'
import NotFound from '@/components/error-pages/NotFound'

Vue.use(Router)

export default new Router({
    mode: 'history',
    routes: [
    { path: '/', name: 'employee-form', component: App },
    { path: '/employee/:id', name: 'EmployeeDetails', component: EmployeeDetails },
    { path: '*', name: 'Not Found', component: NotFound }
  ]
})
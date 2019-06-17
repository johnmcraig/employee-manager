import Vue from 'vue'
import App from './App.vue'
import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue'
import Axios from 'axios'
import router from './router'

Vue.config.productionTip = false

Axios.defaults.baseURL = 'https://localhost:5001/api'

Vue.use(BootstrapVue)

new Vue({
  render: h => h(App),
  router
}).$mount('#app')

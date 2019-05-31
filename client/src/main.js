import Vue from 'vue'
import App from './App.vue'
import Axios from 'axios'

Vue.config.productionTip = false

Axios.defaults.baseURL = 'https://localhost:5001/api'

new Vue({
  render: h => h(App),
}).$mount('#app')

import Vue from 'vue'
import App from './App.vue'

import VueSweetalert2 from 'vue-sweetalert2'

Vue.use(VueSweetalert2)

Vue.config.productionTip = false

window.EventBus = new Vue()

require('./assets/css/main.css')
require('./assets/css/normalize.css')
require('sweetalert2/dist/sweetalert2.min.css')

new Vue({
  render: h => h(App)
}).$mount('#app')

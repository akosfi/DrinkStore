import Vue from 'vue';
import App from './App.vue';
import store from './store/index';

new Vue({
  render: h => h(App),
}).$mount('#app');
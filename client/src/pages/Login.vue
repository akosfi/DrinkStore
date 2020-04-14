<template>
  <div>
      <button v-on:click="login">Login</button>
  </div>
</template>

<script lang="ts">
  import Vue from 'vue';
  import authService from '../services/AuthService';

  export default Vue.extend({
    methods: {
        login: function() {
            authService.login();
        }
    },
    mounted: function() {
      
    },
    
  });
</script>

<style lang="scss">
  

</style>

<template>
  <div id="app">
    <nav-bar/>
    <router-view/>
  </div>
</template>

<script lang="ts">
  import Vue from 'vue';
  import NavBar from './components/NavBar.vue';
  import authService from './services/AuthService';
  import {request} from './util';

  export default Vue.extend({
    components: {
      NavBar,
    },
    created: function() {
      authService.getUser().then(user => {
          request.setAccessToken(user?.access_token || "");
      });
    }
  });
</script>

<style lang="scss">
  @import '~bootstrap/scss/bootstrap';

  

</style>

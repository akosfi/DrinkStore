<template>
  <div id="app">
    <nav-bar/>
    <router-view/>
  </div>
</template>

<script lang="ts">
  import Vue from 'vue';
  import NavBar from './components/NavBar.vue';

  export default Vue.extend({
    components: {
      NavBar,
    }
  });
</script>

<style lang="scss">
  @import '~bootstrap/scss/bootstrap';

  

</style>

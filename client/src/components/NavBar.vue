<template>
  <nav class="navbar navbar-expand-lg navbar-light bg-light">
    <div class="container">
      <a class="navbar-brand" href="#">DrinkStore</a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarTogglerDemo02" aria-controls="navbarTogglerDemo02" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>

      <div class="collapse navbar-collapse" id="navbarTogglerDemo02">
        <ul class="navbar-nav mr-auto mt-2 mt-lg-0">
          <li class="nav-item active">
            <a class="nav-link" href="#">Products</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="#">Orders</a>
          </li>
        </ul>
        <div>
          <span>akos@akos.com</span>
          <button type="button" class="btn btn-primary">Logout</button>
        </div>
      </div>
    </div>
    
  </nav>
  
</template>

<script lang="ts">
  import Vue from 'vue';
  import { mapGetters } from 'vuex'

  export default Vue.extend({
    
  });
</script>

<style lang="scss">
  
</style>

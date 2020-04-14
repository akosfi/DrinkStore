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
          <li 
            v-if="isLoggedIn"
            class="nav-item">
            <a class="nav-link" href="#">Orders</a>
          </li>
        </ul>
        <div>
          <div v-if="!isLoggedIn">
            <button 
              v-on:click="login"
              type="button"
              class="btn btn-primary">Login</button>
          </div>
          <div v-if="isLoggedIn">
            <span>{{email}}</span>
            <button 
              v-on:click="logout"
              type="button"
              class="btn btn-primary">Logout</button>
          </div>
        </div>
      </div>
    </div>
  </nav>
</template>

<script lang="ts">
  import Vue from 'vue';
  import authService from '../services/AuthService';

  export default Vue.extend({
    data: function() {
      return {
        email: "" as string | undefined,
        isLoggedIn: false as boolean,
      }
    },
    methods: {
      logout: function() {
        authService.logout();
      },
      login: function() {
        authService.login();
      }
    },
    mounted: function() {
      authService.getUser().then((user) => {
        this.email = user?.profile?.email;
      });
      authService.isLoggedIn().then((isLoggedIn) => {
        this.isLoggedIn = isLoggedIn;
      });
    }
  });
</script>

<style lang="scss">
  
</style>

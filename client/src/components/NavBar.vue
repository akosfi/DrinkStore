<template>
  <nav class="navbar navbar-expand-lg navbar-light bg-light">
    <div class="container">
      <a class="navbar-brand" href="#">DrinkStore</a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarTogglerDemo02" aria-controls="navbarTogglerDemo02" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>

      <div class="collapse navbar-collapse" id="navbarTogglerDemo02">
        <ul class="navbar-nav mr-auto mt-2 mt-lg-0">
          <li 
            class="nav-item"
            v-bind:class="{ 'active': isRouteActive('/') }">
            <router-link
              to="/"
              class="nav-link"
            >
            Termékek
            </router-link>
          </li>
          <li 
            v-if="isLoggedIn"
            class="nav-item"
            v-bind:class="{ 'active': isRouteActive('/orders') }">
            <router-link
              to="/orders"
              class="nav-link"
            >
            Megrendeléseim
            </router-link>
          </li>
          <li 
            v-if="isLoggedIn"
            class="nav-item"
            v-bind:class="{ 'active': isRouteActive('/admin-product') }">
            <router-link
              to="/admin-product"
              class="nav-link"
            >
            Termékek kezelése
            </router-link>
          </li>
        </ul>
        
        <div>
          <div v-if="!isLoggedIn">
            <button 
              v-on:click="login"
              type="button"
              class="btn btn-primary">Bejelentkezés</button>
          </div>
          <div v-if="isLoggedIn">
            <span>{{email}}</span>
            <button 
              v-on:click="logout"
              type="button"
              class="btn btn-primary">Kijelentkezés</button>
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
      },
      isRouteActive: function(route) {
        return this.$route.path === route;
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

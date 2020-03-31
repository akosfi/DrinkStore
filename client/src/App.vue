<template>
  <div id="app">
    <div id="nav">
      asd
    </div>
    <router-view/>
  </div>
</template>

<script lang="ts">
import Vue from 'vue'
export default Vue.extend({
  mounted: function() {
    this.$store
        .dispatch('products/getProductsAction')
        .then();
  }
});
</script>

<style lang="scss">
</style>

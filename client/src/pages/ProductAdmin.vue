<template>
  <div>
      <product-add></product-add>
  </div>
</template>

<script lang="ts">
  import Vue from 'vue';
  import ProductAdd from '../components/ProductAdd.vue';

  export default Vue.extend({
    components: {
        ProductAdd,
    },
    
  });
</script>

<style lang="scss">
  

</style>

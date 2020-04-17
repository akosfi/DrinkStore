<template>
  <div>
      <product-add></product-add>
      <category-add></category-add>
  </div>
</template>

<script lang="ts">
  import Vue from 'vue';
  import ProductAdd from '../components/ProductAdd.vue';
  import CategoryAdd from '../components/CategoryAdd.vue';

  export default Vue.extend({
    components: {
        ProductAdd,
        CategoryAdd,
    },
    mounted: function() {
        this.$store
            .dispatch('categories/getCategoriesAction')
            .then();

        this.$store
            .dispatch('products/getPackSizesAction')
            .then();
    }
  });
</script>

<style lang="scss">
  

</style>

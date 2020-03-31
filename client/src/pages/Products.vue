<template>
  <div>
      <div class="row">
        <div class="col-3">
            <product-categories></product-categories>
        </div>
        <div class="col-9">
            <product-list></product-list>
        </div>
      </div>
  </div>
</template>

<script lang="ts">
  import Vue from 'vue';
  import ProductCategories from '../components/ProductCategories.vue';
  import ProductList from '../components/ProductList.vue';
  //import { mapGetters } from 'vuex'

  export default Vue.extend({
    components: {
        ProductCategories,
        ProductList,
    },
    mounted: function() {
      this.$store
        .dispatch('categories/getCategoriesAction')
        .then();
    },
    
  });
</script>

<style lang="scss">
  

</style>

<template>
  <div class="category-list">
    <div 
        v-for="category in getCategories"
        :key="category.id"
        class="category-list-item">
        <p 
            v-on:click="categoryClicked(category.id)">
            {{category.name}}
        </p>
        
        <div 
            v-for="subcategory in category.subcategories"
            :key="subcategory.id"
            class="category-list-item-subs"
            v-bind:class="{ 'category-list-item-subs-hidden': category.id !== currentCategoryId }">
            <p 
            v-on:click="subcategoryClicked(subcategory.id)"
            class="category-list-item-subs-item">
            {{subcategory.name}}</p>
        </div>
        
        </div>
  </div>
</template>

<script lang="ts">
  import Vue from 'vue';
  import { mapGetters } from 'vuex'

  export default Vue.extend({
    methods: {
      categoryClicked(categoryId) {
        this.$store.commit('categories/setSelectedCategory', categoryId);
        
        this.$store
            .dispatch('products/getProductsAction', {categoryId})
            .then();
      },
      subcategoryClicked(subcategoryId) {
        this.$store
        .dispatch('products/getProductsAction', {subcategoryId})
        .then();
      },
    },
    computed: {
      ...mapGetters({
        getCategories: 'categories/getCategories',
        getSelectedCategory: 'categories/getSelectedCategory',
      }),
    },
  });
</script>

<style lang="scss">
  .category-list{
    &-item {
      padding-top: 8px;

      &-subs {

        &-item {
          padding-left: 16px;
        }

        &-hidden {
          display: none;
        }
      } 

    }
  }
</style>

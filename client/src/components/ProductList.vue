<template>
    <div>
        <div 
            v-for="product in getProducts"
            :key="product.id"
            class="product">
            <div
                class="product-name">
                {{product.name}}
            </div>
            <div
                class="product-packsize">
                {{product.packSizeQuantity + " " + product.packSizeUnit}}
            </div>
            <div
                class="product-price">
                {{product.unitPrice + ',- Ft'}}
            </div>
            <div 
                class="product-button">
                <button type="button" class="btn btn-primary">Rendelés</button>
            </div>
        </div>
    </div>
  
</template>

<script lang="ts">
  import Vue from 'vue';
  import { mapGetters } from 'vuex'

  export default Vue.extend({
    computed: {
      ...mapGetters({
        getProducts: 'products/getProducts'
      }),
    },
  });
</script>

<style lang="scss">
  .product {
    display: flex;
    flex-direction: row;
    margin-bottom: 16px;
    align-items: center;

    &-name {
      flex: 1 0 auto;
    }

    &-packsize {
      flex: 0 0 10%;
    }

    &-price {
      flex: 0 0 10%;
    }

    &-button {
      flex: 0 0 10%;
    }
  }
</style>

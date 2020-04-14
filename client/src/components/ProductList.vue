<template>
    <div>
        <div class="product">
          <div class="product-name"></div>
          <div class="product-packsize"><b>Kiszerelés</b></div>
          <div class="product-price"><b>Ár</b></div>
          <div v-if="isLoggedIn" class="product-button"></div>
        </div>
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
                v-if="isLoggedIn"
                class="product-button">
                <button type="button" class="btn btn-primary">Rendelés</button>
            </div>
        </div>
    </div>
  
</template>

<script lang="ts">
  import Vue from 'vue';
  import { mapGetters } from 'vuex'
  import authService from '../services/AuthService';

  export default Vue.extend({
    data: function() {
      return {
        isLoggedIn: false,
      }
    },
    computed: {
      ...mapGetters({
        getProducts: 'products/getProducts'
      }),
    },
    mounted: function() {
      authService.isLoggedIn().then((isLoggedIn) => {
        this.isLoggedIn = isLoggedIn;
      });
    }
  });
</script>

<style lang="scss">
  .product {
    display: flex;
    flex-direction: row;
    margin-top: 16px;
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
      flex: 0 0 15%;
    }
  }
</style>

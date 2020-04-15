<template>
    <div>
        <div class="product">
          <div class="product-name"></div>
          <div class="product-packsize"><b>Kiszerelés</b></div>
          <div class="product-price"><b>Ár</b></div>
          <div v-if="isLoggedIn" class="product-order"></div>
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
                class="product-order">
                
                <div 
                  v-if="currentOrder.id != product.id"
                  class="input-group">
                  <button 
                    v-if="currentOrder.id !== product.id"
                    v-on:click="setCurrentOrder(product.id)"
                    class="btn btn-primary"
                    type="button">
                    Rendelés</button>
                </div>

                <div 
                  v-if="currentOrder.id == product.id"
                  class="input-group">
                  <select v-model="currentOrder.quantity" class="custom-select" id="inputGroupSelect04">
                    <option v-for="i in 20" :key="i" v-bind:value="i">{{i}}</option>
                  </select>
                  <div class="input-group-append">
                    <button v-on:click="addToCart(product)" class="btn btn-outline-primary" type="button">Kosárba</button>
                  </div>
                </div>

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
        currentOrder: {
          id: null,
          quantity: 1,
        }
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
    },
    methods: {
      setCurrentOrder: function(id) {
        this.currentOrder = {id: id, quantity: 1};
      },
      addToCart: function(product) {
        this.$store.dispatch('cart/addProductAction', {...this.currentOrder, ...product});
        this.currentOrder = {id: null, quantity: 1};
      },
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

    &-order {
      flex: 0 0 20%;
    }
  }
</style>

<template>
  <div class="container">
        <div v-if="getCart && getCart.length > 0">
            <h3 class="my-3">Befejezetlen megrendelés</h3>
            <div class="order">
                <div class="order-name"><b>Termék</b></div>
                <div class="order-quantity"><b>Mennyiség</b></div>
                <div class="order-total"><b>Összeg</b></div>
                <div class="order-dbutton"></div>
            </div>
            <div 
                v-for="item in getCart"
                v-bind:key="item.id"
                class="order">
                <div class="order-name">
                    {{item.name}}
                </div>
                <div class="order-quantity">
                    {{item.quantity}}
                </div>
                <div class="order-total">
                    {{item.quantity * item.unitPrice}},- Ft
                </div>
                <div class="order-dbutton">
                    <button v-on:click="removeProductFromCart(item.id)" type="button" class="btn btn-danger">Törlés</button>
                </div>
            </div>
            <div class="order">
                <div class="order-name"></div>
                <div class="order-quantity"></div>
                <div class="order-total"><b>{{getTotalPrice}},-Ft</b></div>
                <div v-on:click="makeOrder()" class="order-dbutton"><button type="button" class="btn btn-success">Rendelés</button></div>
            </div>
        </div>
        
        
        <h3 class="py-3">Megrendelések</h3>
        <div class="row">
            <div class="col-3">
                <ul class="list-group">
                    <li 
                        v-on:click="setCurrentOrder(order.id)"
                        v-bind:class="{ 'active': getCurrentOrder && getCurrentOrder.id == order.id }"
                        v-for="order in getOrders"
                        v-bind:key="order.id"
                        class="list-group-item">
                        <span>Azonosító: {{order.id}}</span>
                        <span>Dátum: {{formatDate(order.orderDate)}}</span>
                    </li>
                </ul>
            </div>
            <div v-if="getCurrentOrder" class="col-9">
                <div class="row order-detail">
                    <div class="col-4 order-detail-key">Azonosító</div>
                    <div class="col-8 order-detail-value order-detail-value-text">{{getCurrentOrder.id}}</div>
                </div>
                <div class="row order-detail">
                    <div class="col-4 order-detail-key">Dátum</div>
                    <div class="col-8 order-detail-value order-detail-value-text">{{formatDate(getCurrentOrder.orderDate)}}</div>
                </div>
                <div class="row order-detail">
                    <div class="col-4 order-detail-key">Termékek</div>
                    <div class="col-8 order-detail-value order-detail-value-list">
                        <div
                            v-for="product in getCurrentOrder.products"
                            v-bind:key="product.id"
                            class="order-detail-value-list-item"
                        >
                            <span>{{product.name}}</span>
                            <span>{{product.quantity}} x {{product.packSizeQuantity + " " + product.packSizeUnit}}</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
  </div>
</template>

<script lang="ts">
    import Vue from 'vue';
    import { mapGetters } from 'vuex';

    export default Vue.extend({
        components: {
            
        },
        computed: {
            ...mapGetters({
                getCart: 'cart/getProducts',
                getOrders: 'orders/getOrders',
                getCurrentOrder: 'orders/getCurrentOrder'
            }),
            getTotalPrice: function() {
                let sum = 0;
                this.getCart.forEach(cartItem => {
                    sum += cartItem.quantity * cartItem.unitPrice;
                });
                return sum;
            }
        },
        methods: {
            removeProductFromCart: function(id) {
                this.$store.dispatch('cart/removeProductAction', id);
            },
            makeOrder: function() {
                this.$store.dispatch('cart/makeOrderAction');
            },
            setCurrentOrder: function(id) {
                this.$store.dispatch('orders/getOrderAction', id);
            },
            formatDate: function(dateString) {
                return (new Date(dateString)).toLocaleString();
            }
        },
        mounted: function(){
            this.$store.dispatch('orders/getOrdersAction');
        }
    });
</script>

<style lang="scss">
    .list-group-item {
        cursor: pointer;
        & span {
            display: block;
        
        }
    }
    .order {
        margin: 8px 0px;
        display: flex;
        justify-content: center;
        align-items: center;
        
        &-name {
            flex: 1 0 auto;
        }

        &-quantity {
            flex: 0 0 10%;
        }

        &-total {
            flex: 0 0 10%;
        }

        &-dbutton {
            text-align: right;
            flex: 0 0 15%;
        }
    }
    .order-detail {
        &-key {
            padding: 8px;
            background: #ededed;
            font-weight: bold;
        }
        &-value {
            padding: 8px;
            &-text {
                text-align: right;
            }
            &-list {
                &-item {
                    display: flex;
                    justify-content: space-between;
                }
            }
            
        }
    }
</style>

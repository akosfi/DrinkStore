<template>
  <div class="container">
        <h3 class="my-3">Befejezetlen megrendelés</h3>
        <div class="order">
            <div class="order-name"><b>Termék</b></div>
            <div class="order-quantity"><b>Mennyiség</b></div>
            <div class="order-total"><b>Összeg</b></div>
            <div class="order-dbutton"></div>
        </div>
        <div class="order">
            <div class="order-name">
                La Fiesta
            </div>
            <div class="order-quantity">
                2 * 15 l
            </div>
            <div class="order-total">
                14 000,-Ft
            </div>
            <div class="order-dbutton">
                <button type="button" class="btn btn-danger">Törlés</button>
            </div>
        </div>
        <div class="order">
            <div class="order-name"></div>
            <div class="order-quantity"></div>
            <div class="order-total"><b>14 000,-Ft</b></div>
            <div class="order-dbutton"><button type="button" class="btn btn-success">Rendelés</button></div>
        </div>

        <div class="row">
            <div class="col-3">
                <h3 class="py-3">Megrendelések</h3>
                <ul class="list-group">
                    <li class="list-group-item active">
                        <span>Azonosító: 2328</span>
                        <span>Dátum: 2020. 02. 02.</span>
                    </li>
                    <li class="list-group-item">Dapibus ac facilisis in</li>
                    <li class="list-group-item">Morbi leo risus</li>
                    <li class="list-group-item">Porta ac consectetur ac</li>
                    <li class="list-group-item">Vestibulum at eros</li>
                </ul>
            </div>
            <div class="col-9">
                
            </div>
        </div>
  </div>
</template>

<script lang="ts">
  import Vue from 'vue';

  export default Vue.extend({
    components: {
        
    },
    mounted: function() {
      console.log("hi!")
    },
    
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
</style>

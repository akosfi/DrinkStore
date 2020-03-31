<template>
    <div>
        {{ mine }}
    </div>
</template>


<script lang="ts">
    import Vue from 'vue';
    import { mapGetters } from 'vuex';

    const App = Vue.extend({
        data: function() {
            return {
                mine: 'aaaaaaaaa',
            };
        },
        mounted: function() {
            this.$store
                .dispatch('drinks/getDrinks')
                .then();
        }
    });

    export default App; 
</script>

<style lang="scss">

</style>
<template>
    <div>
        { mine }
    </div>
</template>


<script lang="ts">
    import Vue from 'vue'

    const App = Vue.extend({
        data: function() {
            return {
                mine: 'mine',
            };
        }
    });

    export default App; 
</script>

<style lang="scss">

</style>
<template>
    <div class="container">
        <h3 class="py-3">Kategória hozzáadása</h3>
        <div class="form-row">
            <div class="form-group col-md-6">
                <label for="categoryName">Kategória elnevezése</label>
                <input v-model="name" type="text" class="form-control" id="categoryName" placeholder="Kategória elnevezése">
            </div>
            <div class="form-group col-md-6">
                <label for="parentCategory">Szülő kategória (nem kötelező)</label>
                <select 
                    v-model="parentCategoryId"
                    id="parentCategory"
                    class="form-control">
                    <option selected disabled value="0">Kérem válasszon...</option>
                    <option 
                        v-for="category in getCategories"
                        v-bind:key="category.id"
                        v-bind:value="category.id"
                        selected>{{category.name}}</option>
                </select>
            </div>
        </div>
        <div class="d-flex justify-content-end">
            <button v-on:click="addCategory()" type="button" class="btn btn-primary">Felvétel</button>
        </div>
    </div>
</template>

<script lang="ts">
    import Vue from 'vue';
    import { mapGetters } from 'vuex';

    export default Vue.extend({
        data: function () {
            return {
                name: '',
                parentCategoryId: 0,
            };
        },
        components: {
            
        },
        computed: {
            ...mapGetters({
                getCategories: 'categories/getCategories',
            }),
        },
        methods: {
            addCategory: function () {
                const category = {name: this.name};
                if(this.parentCategoryId) category['parentCategoryId'] = this.parentCategoryId;
                this.$store
                    .dispatch('categories/addCategoryAction', category)
                    .then(() => {
                        this.name = "";
                        this.parentCategoryId = 0;
                        this.$store.dispatch('categories/getCategoriesAction');
                    });
            }
        }
    });
</script>

<style lang="scss">
    
</style>

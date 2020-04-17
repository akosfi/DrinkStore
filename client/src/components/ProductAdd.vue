<template>
    <div class="container">
        <h3 class="py-3">Termék hozzáadása</h3>
        <form>
            <div class="form-group row">
                <label for="name" class="col-sm-4 col-form-label">Név</label>
                <div class="col-sm-8">
                    <input v-model="name" type="text" class="form-control" id="name" placeholder="Termék neve">
                </div>
            </div>
            <div class="form-group row">
                <label for="price" class="col-sm-4 col-form-label">Egységár</label>
                <div class="col-sm-8">
                    <div class="input-group">
                        <input v-model="unitPrice" type="number" class="form-control" id="price" placeholder="Termék egységára">
                        <div class="input-group-append">
                            <span class="input-group-text">,- Ft</span>
                        </div>                        
                    </div>
                </div>
            </div>
            <div class="form-group row">
                <label for="category" class="col-sm-4 col-form-label">Kategória</label>
                <div class="col-sm-8">
                    <select 
                        v-on:change="categorySelected"
                        v-model="categoryId"
                        id="category"
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
            <div class="form-group row">
                <label for="subcategory" class="col-sm-4 col-form-label">Alkategória</label>
                <div class="col-sm-8">
                    <select 
                        v-model="subcategoryId"
                        id="subcategory"
                        class="form-control">
                        <option v-if="!categoryId" selected disabled value="0">Válasszon kategóriát előszőr!</option>
                        <option v-if="categoryId && getSubcategories(categoryId).length <= 0" selected disabled value="0">Ehhez a kategóriához nem tartozik alkategória!</option>
                        <option v-if="categoryId && getSubcategories(categoryId).length > 0" selected disabled value="0">Kérem válasszon...</option>
                        <option 
                            v-for="category in getSubcategories(categoryId)"
                            v-bind:key="category.id"
                            v-bind:value="category.id"
                            selected>{{category.name}}</option>
                    </select>
                </div>
            </div>
            <div class="form-group row">
                <label for="packSize" class="col-sm-4 col-form-label">Kiszerelés</label>
                <div class="col-sm-8">
                    <select 
                        v-model="packSizeId"
                        id="packSize"
                        class="form-control">
                        <option selected disabled value="0">Kérem válasszon...</option>
                        <option 
                            v-for="ps in getPackSizes"
                            v-bind:key="ps.id"
                            v-bind:value="ps.id"
                            selected>{{ps.quanitity + " " + ps.unit}}</option>
                    </select>
                </div>
            </div>
            <div class="d-flex justify-content-between">
                <button v-on:click="resetForm()" type="button" class="btn btn-warning">Törlés</button>
                <button v-on:click="addProduct()" type="button" class="btn btn-primary">Felvétel</button>
            </div>
        </form>
    </div>
</template>

<script lang="ts">
    import Vue from 'vue';
    import { mapGetters } from 'vuex';

    export default Vue.extend({
        data: function () {
            return {
                name: '',
                unitPrice: '',
                categoryId: 0,
                subcategoryId: 0,
                packSizeId: 0,
            };
        },
        components: {
            
        },
        computed: {
            ...mapGetters({
                getCategories: 'categories/getCategories',
                getSubcategories: 'categories/getSubcategories',
                getPackSizes: 'products/getPackSizes',
            }),
        },
        methods: {
            setSelectedCategory: function(id) {
                this.$store
                .dispatch('categories/setSelectedCategory', id)
                .then();
            },
            categorySelected: function(event) {
                const id = event.target.value;
                this.subcategoryId = 0;
            },
            addProduct: function() {
                this.$store
                    .dispatch('products/addProductAction', {
                        name: this.name,
                        unitPrice: Number(this.unitPrice),
                        categoryId: this.categoryId,
                        subcategoryId: this.subcategoryId,
                        packSizeId: this.packSizeId,
                    })
                    .then(() => this.resetForm());
            },
            resetForm: function() {
                this.name = '';
                this.unitPrice = '';
                this.categoryId = 0;
                this.subcategoryId = 0;
                this.packSizeId = 0;
            }
        }
    });
</script>

<style lang="scss">
    
</style>

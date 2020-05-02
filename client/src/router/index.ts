import Vue from 'vue'
import VueRouter from 'vue-router'
import authService from '../services/AuthService';
import { request } from '@/util';

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Products',
    component: () => import('../pages/Products.vue'),
    meta: {
      isSecure: false
    }
  },
  {
    path: '/orders',
    name: 'Orders',
    component: () => import('../pages/Orders.vue'),
    meta: {
      isSecure: true
    }
  },
  {
    path: '/admin-product',
    name: 'AdminProducts',
    component: () => import('../pages/ProductAdmin.vue'),
    meta: {
      isAdmin: true
    }
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
});


router.beforeEach((to, from, next) => {
  if (to.matched.some(record => record.meta.isSecure)) {
    authService.isLoggedIn().then((isLoggedIn) => {
      if (isLoggedIn) {
        next();
      } else {
        authService.login();
      }
    });
  } 
  /*else if (to.matched.some(record => record.meta.isAdmin)) {
    authService.getUser().then(user => {
      console.log(user);
      next();
    });
  } */
  else {
    next();
  }
});

export default router;

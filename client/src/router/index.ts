import Vue from 'vue'
import VueRouter from 'vue-router'
import authService from '../services/AuthService';

Vue.use(VueRouter)

const routes = [
  {
    path: '/login',
    name: 'Login',
    component: () => import('../pages/Login.vue'),
    meta: {
      isSecure: false
    }
  },
  {
    path: '/',
    name: 'Products',
    component: () => import('../pages/Products.vue'),
    meta: {
      isSecure: true
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
        next({
          path: '/login',
          query: { redirect: to.fullPath }
        });
      }
    });
  } else {
    next();
  }
});

export default router;

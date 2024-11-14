import { createRouter, createWebHistory } from 'vue-router';
import HomePage from './components/Home.vue';
import AboutPage from './components/About.vue';
import SignIn from './components/SignIn.vue';
import SignUp from './components/SignUp.vue';
import JobSearch from './components/JobSearch.vue';
import ImmigrationAssistance from './components/ImmigrationAssistance.vue';

const routes = [
  { path: '/signin', name: 'SignIn', component: SignIn },
  { path: '/signup', name: 'SignUp', component: SignUp },
  { path: '/home', name: 'Home', component: HomePage },
  { path: '/about', name: 'About', component: AboutPage },
  { path: '/jobs', name: 'JobSearch', component: JobSearch },
  { path: '/immigration-assistance', name: 'ImmigrationAssistance', component: ImmigrationAssistance },
  { path: '/', redirect: '/signin' },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;

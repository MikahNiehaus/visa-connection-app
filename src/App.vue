<template>
  <div id="app">
    <h1>Visa Connection App</h1>
    <nav>
      <router-link to="/">Home</router-link> |
      <router-link to="/about">About</router-link>
    </nav>
    <router-view></router-view> <!-- Loads the component based on the route -->
  </div>
</template>

<script>
export default {
  name: 'App',
};
</script>

<template>
  <div id="app">
    <header class="app-header">
      <h1 class="logo">Visa Connection</h1>
      <nav class="navbar">
        <router-link to="/home">Home</router-link>
        <router-link to="/about">About</router-link>
        <router-link to="/signin">Sign In</router-link>
        <router-link to="/signup">Sign Up</router-link>
      </nav>
    </header>
    <main class="app-content">
      <router-view></router-view> <!-- This is where page content loads -->
    </main>
  </div>
</template>

<script>
export default {
  name: 'App',
};
</script>

<style>
/* Global layout and styling for the header and main content */

.app-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 20px 40px;
  background-color: #2c3e50;
  color: white;
}

.logo {
  font-size: 1.8rem;
  font-weight: bold;
  color: white;
}

.navbar {
  display: flex;
  gap: 20px;
}

.navbar a {
  color: #42b983;
  text-decoration: none;
  font-weight: bold;
}

.navbar a:hover {
  color: #7bcabc;
  text-decoration: underline;
}

.app-content {
  padding: 40px 20px;
}
</style>

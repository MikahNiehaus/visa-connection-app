<template>
  <div class="home">
    <h2>Home Page</h2>
    <p>Welcome to the Visa Connection App home page. Here, you can learn more about visa opportunities.</p>
    <PrimaryButton>Learn More</PrimaryButton>
  </div>
</template>

<script>
import PrimaryButton from './Button.vue';

export default {
  name: 'HomePage',
  components: {
    PrimaryButton,
  },
};
</script>

<style scoped>
.home {
  padding: 20px;
  background-color: white;
  border-radius: 8px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}

h2 {
  color: #42b983;
}
</style>

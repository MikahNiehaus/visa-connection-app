<template>
  <div class="about">
    <h2>About Page</h2>
    <p>This page provides information about the Visa Connection App and its mission to connect job seekers with visa opportunities.</p>
    <PrimaryButton>Contact Us</PrimaryButton>
  </div>
</template>

<script>
import PrimaryButton from './Button.vue';

export default {
  name: 'AboutPage',
  components: {
    PrimaryButton,
  },
};
</script>

<style scoped>
.about {
  padding: 20px;
  background-color: white;
  border-radius: 8px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}

h2 {
  color: #42b983;
}
</style>

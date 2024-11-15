<template>
    <div class="auth-container">
      <h2>Sign Up</h2>
      <form @submit.prevent="handleSignUp">
        <label for="username">Username</label>
        <input type="text" v-model="username" id="username" required />
  
        <label for="password">Password</label>
        <input type="password" v-model="password" id="password" required />
  
        <button type="submit">Sign Up</button>
      </form>
    </div>
  </template>
  
  <script>
  export default {
    name: 'SignUp',
    data() {
      return {
        username: '',
        password: '',
      };
    },
    methods: {
      handleSignUp() {
        this.$router.push('/home');
      },
    },
  };
  </script>
  
  <style scoped>
  .auth-container {
    max-width: 400px;
    margin: 60px auto;
    padding: 20px;
    background-color: white;
    border-radius: 8px;
    box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
    text-align: center;
  }
  
  label {
    display: block;
    margin: 10px 0 5px;
  }
  
  input {
    width: 100%;
    padding: 10px;
    margin-bottom: 15px;
    border: 1px solid #ccc;
    border-radius: 5px;
  }
  
  button {
    width: 100%;
  }
  </style>
  
<template>
    <div>
      <h2>Visa-Sponsored Job Opportunities</h2>
      <p v-if="loading">Loading...</p>
      <p v-if="error">{{ error }}</p>
      <ul v-else>
        <li v-for="opportunity in opportunities" :key="opportunity.id">
          {{ opportunity.title }}
        </li>
      </ul>
    </div>
  </template>
  
  <script>
  import api from '../api';
  
  export default {
    name: 'VisaOpportunities',
    data() {
      return {
        opportunities: [],
        loading: true,
        error: null,
      };
    },
    async created() {
      try {
        const response = await api.fetchOpportunities();
        this.opportunities = response.data;
      } catch (error) {
        this.error = "Failed to load opportunities";
      } finally {
        this.loading = false;
      }
    },
  };
  </script>
  
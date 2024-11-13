<template>
    <div class="job-search-container">
      <h2>Find Visa-Sponsored Jobs</h2>
      
      <!-- Search Form -->
      <form @submit.prevent="searchJobs" class="search-form">
        <label for="keyword">Job Title or Keywords</label>
        <input type="text" id="keyword" v-model="searchTerm" placeholder="e.g., Software Engineer, Marketing" />
        
        <label for="location">Location</label>
        <input type="text" id="location" v-model="location" placeholder="e.g., New York, Berlin" />
  
        <label for="country">EU Country</label>
        <select id="country" v-model="selectedCountry">
          <option value="">All EU Countries</option>
          <option v-for="country in euCountries" :key="country" :value="country">
            {{ country }}
          </option>
        </select>
  
        <button type="submit">Search</button>
      </form>
  
      <!-- Job Results -->
      <div v-if="filteredJobs.length" class="job-results">
        <h3>Job Results</h3>
        <ul>
          <li v-for="job in filteredJobs" :key="job.id" class="job-item">
            <h4>{{ job.title }}</h4>
            <p>{{ job.company }} - {{ job.location }}</p>
            <p>{{ job.description }}</p>
            <button @click="applyForJob(job)">Apply</button>
          </li>
        </ul>
      </div>
      <p v-else-if="searchExecuted">No jobs found currently in the selected location or field. Please try a different search.</p>
    </div>
  </template>
  
  <script>
  export default {
    name: 'JobSearch',
    data() {
      return {
        searchTerm: '',
        location: '',
        selectedCountry: '',
        searchExecuted: false,
        euCountries: [
          'Austria', 'Belgium', 'Bulgaria', 'Croatia', 'Cyprus', 'Czech Republic',
          'Denmark', 'Estonia', 'Finland', 'France', 'Germany', 'Greece', 'Hungary',
          'Ireland', 'Italy', 'Latvia', 'Lithuania', 'Luxembourg', 'Malta', 'Netherlands',
          'Poland', 'Portugal', 'Romania', 'Slovakia', 'Slovenia', 'Spain', 'Sweden'
        ],
        jobs: [
          { id: 1, title: 'Software Engineer', company: 'TechCorp', location: 'Berlin, Germany', description: 'Develop web applications with a focus on performance.' },
          { id: 2, title: 'Data Scientist', company: 'DataX', location: 'Paris, France', description: 'Analyze data and build predictive models.' },
          { id: 3, title: 'Marketing Specialist', company: 'GlobalAds', location: 'Amsterdam, Netherlands', description: 'Manage and optimize digital marketing campaigns.' },
          { id: 4, title: 'Project Manager', company: 'BizSolutions', location: 'Rome, Italy', description: 'Coordinate project activities and ensure timely delivery.' },
        ],
      };
    },
    computed: {
      filteredJobs() {
        return this.jobs.filter((job) => {
          const matchesTitle = this.searchTerm ? job.title.toLowerCase().includes(this.searchTerm.toLowerCase()) : true;
          const matchesLocation = this.location ? job.location.toLowerCase().includes(this.location.toLowerCase()) : true;
          const matchesCountry = this.selectedCountry ? job.location.includes(this.selectedCountry) : true;
          return matchesTitle && matchesLocation && matchesCountry;
        });
      },
    },
    methods: {
      searchJobs() {
        this.searchExecuted = true;
      },
      applyForJob(job) {
        alert(`You applied for the position: ${job.title} at ${job.company}`);
      },
    },
  };
  </script>
  
  <style scoped>
  .job-search-container {
    max-width: 600px;
    margin: auto;
    padding: 20px;
    background-color: white;
    border-radius: 8px;
    box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
    text-align: left;
  }
  
  h2 {
    text-align: center;
    color: #2c3e50;
    margin-bottom: 20px;
  }
  
  .search-form label {
    display: block;
    margin-top: 10px;
  }
  
  .search-form input, .search-form select {
    width: 100%;
    padding: 10px;
    margin-top: 5px;
    margin-bottom: 15px;
    border: 1px solid #ccc;
    border-radius: 5px;
  }
  
  button {
    width: 100%;
    padding: 10px;
    background-color: #42b983;
    color: white;
    border: none;
    border-radius: 5px;
    font-weight: bold;
    cursor: pointer;
  }
  
  button:hover {
    background-color: #368f6b;
  }
  
  .job-results {
    margin-top: 30px;
  }
  
  .job-item {
    border-bottom: 1px solid #ddd;
    padding: 15px 0;
  }
  
  .job-item h4 {
    color: #42b983;
  }
  
  .job-item p {
    margin: 5px 0;
  }
  </style>
  
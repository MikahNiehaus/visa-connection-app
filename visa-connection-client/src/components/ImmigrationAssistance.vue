<template>
  <div class="immigration-assistance">
    <h1>Find Your Ideal Immigration Destination</h1>
    <form @submit.prevent="handleFormSubmit">
      <label>Employment Type:</label>
      <div class="checkbox-group">
        <input type="checkbox" id="remote" value="Remote" v-model="formData.employmentType" />
        <label for="remote">Remote Work</label>
        <input type="checkbox" id="onsite" value="On-site" v-model="formData.employmentType" />
        <label for="onsite">On-site Work</label>
      </div>

      <label>Language Preference:</label>
      <select v-model="formData.language" multiple>
        <option v-for="language in languages" :key="language" :value="language">
          {{ language }}
        </option>
      </select>

      <label>Preferred Countries:</label>
      <select v-model="formData.countryPreferences" multiple>
        <option v-for="country in countries" :key="country" :value="country">{{ country }}</option>
      </select>

      <label>Cost of Living:</label>
      <input type="range" min="1" max="3" v-model="formData.costOfLiving" />
      <div class="cost-labels">
        <span>Low</span>
        <span>Medium</span>
        <span>High</span>
      </div>

      <label>Climate Preference:</label>
      <select v-model="formData.climate">
        <option disabled value="">Select Climate</option>
        <option>Cold</option>
        <option>Mild</option>
        <option>Warm</option>
      </select>

      <button type="submit">Get Recommendations</button>
    </form>

    <div v-if="recommendations.length" class="recommendations">
      <h2>Recommended Countries and Visa Information</h2>
      <ul>
        <li v-for="country in recommendations" :key="country.name">
          <h3>{{ country.name }}</h3>
          <p><strong>Language Compatibility:</strong> {{ country.language }}</p>
          <p><strong>Cost of Living:</strong> {{ country.costOfLiving }}</p>
          <p><strong>Climate:</strong> {{ country.climate }}</p>
          <p><strong>Visa Information:</strong> {{ country.visaInfo }}</p>
        </li>
      </ul>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      formData: {
        employmentType: [],
        language: [],
        countryPreferences: [],
        costOfLiving: 2,
        climate: ""
      },
      languages: ["English", "Spanish", "French", "German", "Dutch", "Mandarin", "Japanese"],
      countries: ["Netherlands", "Canada", "Australia", "New Zealand", "Germany", "Singapore"],
      recommendations: []
    };
  },
  methods: {
    async handleFormSubmit() {
      try {
        const response = await fetch(`${process.env.VUE_APP_API_URL}/recommendations/get-recommendations`, {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify(this.formData)
        });
        if (response.ok) {
          this.recommendations = await response.json();
        } else {
          console.error("Error fetching recommendations:", response.status);
        }
      } catch (error) {
        console.error("Failed to fetch recommendations:", error);
      }
    }
  }
};
</script>
<style scoped>
.immigration-assistance {
  max-width: 700px;
  margin: 0 auto;
  font-family: Arial, sans-serif;
}

form {
  background: #f9f9f9;
  padding: 20px;
  border-radius: 8px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}

label {
  font-weight: bold;
  margin-top: 10px;
  display: block;
}

.checkbox-group {
  display: flex;
  gap: 10px;
  margin-bottom: 10px;
}

input[type="range"] {
  width: 100%;
}

.cost-labels {
  display: flex;
  justify-content: space-between;
  font-size: 0.9em;
  margin-bottom: 10px;
}

button {
  background-color: #2c3e50;
  color: white;
  padding: 10px;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  font-weight: bold;
  margin-top: 15px;
}

button:hover {
  background-color: #34495e;
}

.recommendations {
  margin-top: 20px;
  padding: 10px;
  background: #e0f7fa;
  border-radius: 8px;
}

.recommendations h3 {
  margin: 0;
}

.recommendations p {
  margin: 5px 0;
}
</style>

<template>
  <div class="immigration-assistance">
    <h1>Find Your Ideal Immigration Destination</h1>
    <form @submit.prevent="handleFormSubmit">

      <!-- Employment Type -->
      <label>Employment Type:</label>
      <div class="checkbox-group">
        <input type="checkbox" id="remote" value="Remote" v-model="formData.employmentType" />
        <label for="remote">Remote Work</label>
        <input type="checkbox" id="onsite" value="On-site" v-model="formData.employmentType" />
        <label for="onsite">On-site Work</label>
      </div>

      <!-- Language Preference -->
      <label>Language Preference:</label>
      <div class="checkbox-group">
        <div v-for="language in languages" :key="language" class="checkbox-item">
          <input type="checkbox" :id="language" :value="language" v-model="formData.language" />
          <label :for="language">{{ language }}</label>
        </div>
      </div>

      <!-- Current Country for Cost of Living Adjustment -->
      <label>Your Current Country:</label>
      <input type="text" v-model="currentCountry" placeholder="Search your country..." list="countriesList" />
      <datalist id="countriesList">
        <option v-for="country in countries" :key="country">{{ country }}</option>
      </datalist>
      <button type="button" @click="setCostOfLivingBasedOnLocation">Set Cost of Living Based on Current Country</button>

      <!-- Preferred Countries -->
      <label>Preferred Countries:</label>
      <input type="text" v-model="preferredCountryFilter" placeholder="Search preferred countries..." />
      <div class="checkbox-group">
        <div v-for="country in filteredCountries" :key="country" class="checkbox-item">
          <input type="checkbox" :id="country" :value="country" v-model="formData.countryPreferences" />
          <label :for="country">{{ country }}</label>
        </div>
      </div>

      <!-- Job Sector -->
      <label>Preferred Job Sector:</label>
      <select v-model="formData.jobSector">
        <option disabled value="">Select Sector</option>
        <option v-for="sector in jobSectors" :key="sector">{{ sector }}</option>
      </select>

      <!-- Education Level -->
      <label>Your Education Level:</label>
      <select v-model="formData.educationLevel">
        <option disabled value="">Select Education Level</option>
        <option v-for="level in educationLevels" :key="level">{{ level }}</option>
      </select>

      <!-- Salary Expectations -->
      <label>Minimum Expected Monthly Salary (USD):</label>
      <input type="number" v-model="formData.salaryExpectations" placeholder="e.g., 3000" />

      <!-- Work-Life Balance Importance -->
      <label>How Important is Work-Life Balance?</label>
      <input type="range" min="1" max="5" v-model="formData.workLifeBalance" />
      <small>(1: Not Important, 5: Very Important)</small>

      <!-- Cost of Living -->
      <label>Cost of Living:</label>
      <div class="cost-slider">
        <input type="range" min="500" max="5000" step="100" v-model="formData.costOfLiving" />
        <span class="cost-display">USD {{ formData.costOfLiving }}</span>
      </div>

      <!-- Climate Preference -->
      <label>Climate Preference:</label>
      <select v-model="formData.climate">
        <option disabled value="">Select Climate</option>
        <option>Cold</option>
        <option>Mild</option>
        <option>Warm</option>
      </select>

      <button type="submit">Get Recommendations</button>
    </form>

    <!-- Display Recommendations -->
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
        costOfLiving: 3000,
        climate: "",
        jobSector: "",
        educationLevel: "",
        salaryExpectations: 3000,
        workLifeBalance: 3
      },
      currentCountry: "",
      preferredCountryFilter: "",
      languages: ["English", "Spanish", "French", "German", "Dutch", "Mandarin", "Japanese"],
      countries: [
        "Austria", "Belgium", "Bulgaria", "Croatia", "Cyprus", "Czech Republic", "Denmark",
        "Estonia", "Finland", "France", "Germany", "Greece", "Hungary", "Ireland", "Italy",
        "Latvia", "Lithuania", "Luxembourg", "Malta", "Netherlands", "Poland", "Portugal",
        "Romania", "Slovakia", "Slovenia", "Spain", "Sweden"
      ],
      jobSectors: ["Technology", "Healthcare", "Finance", "Education", "Engineering", "Marketing"],
      educationLevels: ["High School", "Associate's Degree", "Bachelor's Degree", "Master's Degree", "Ph.D."],
      recommendations: []
    };
  },
  computed: {
    filteredCountries() {
      return this.countries.filter((country) =>
        country.toLowerCase().includes(this.preferredCountryFilter.toLowerCase())
      );
    }
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
    },
    setCostOfLivingBasedOnLocation() {
      const countryCostOfLivingMap = {
        "Austria": 2500,
        "Belgium": 2400,
        "France": 2600,
        "Germany": 2500,
        "Netherlands": 2600
      };
      this.formData.costOfLiving = countryCostOfLivingMap[this.currentCountry] || 3000;
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
  flex-wrap: wrap;
  gap: 10px;
  margin-bottom: 10px;
}

.checkbox-item {
  display: flex;
  align-items: center;
}

input[type="range"] {
  width: 100%;
}

.cost-slider {
  display: flex;
  align-items: center;
  justify-content: space-between;
}

.cost-display {
  font-weight: bold;
  margin-left: 10px;
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

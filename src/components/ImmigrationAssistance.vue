<template>
    <div class="immigration-assistance">
      <h1>Find Your Ideal Immigration Destination</h1>
  
      <!-- Form to Capture User Preferences -->
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
        <select v-model="formData.language" multiple>
          <option v-for="language in languages" :key="language" :value="language">
            {{ language }}
          </option>
        </select>
        <small>Select all languages you are comfortable with. The first choice will be considered as preferred.</small>
  
        <!-- Country Preference -->
        <label>Preferred Country (Optional):</label>
        <select v-model="formData.countryPreference">
          <option disabled value="">Select Country</option>
          <option v-for="country in countries" :key="country" :value="country">{{ country }}</option>
        </select>
  
        <!-- Work Visa Sponsorship -->
        <div class="checkbox-group">
          <input type="checkbox" id="visa-sponsorship" v-model="formData.requiresVisaSponsorship" />
          <label for="visa-sponsorship">Require Visa Sponsorship</label>
        </div>
  
        <!-- Family-Friendly Destination -->
        <div class="checkbox-group">
          <input type="checkbox" id="family-friendly" v-model="formData.familyFriendly" />
          <label for="family-friendly">Looking for Family-Friendly Destination</label>
        </div>
  
        <!-- Cost of Living -->
        <label>Cost of Living:</label>
        <input type="range" min="1" max="3" v-model="formData.costOfLiving" />
        <div class="cost-labels">
          <span>Low</span>
          <span style="margin-left: 30px;">Medium</span>
          <span style="margin-left: 30px;">High</span>
        </div>
  
        <!-- Climate Preference -->
        <label>Climate Preference:</label>
        <select v-model="formData.climate">
          <option disabled value="">Select Climate</option>
          <option>Cold</option>
          <option>Mild</option>
          <option>Warm</option>
        </select>
  
        <!-- Healthcare Quality -->
        <label>Healthcare Quality:</label>
        <input type="range" min="1" max="5" v-model="formData.healthcareQuality" />
  
        <!-- Safety Level -->
        <label>Safety Level:</label>
        <input type="range" min="1" max="5" v-model="formData.safetyLevel" />
  
        <!-- Income Level -->
        <label>Income Level:</label>
        <input type="range" min="1" max="5" v-model="formData.incomeLevel" />
  
        <!-- Submit Button -->
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
  import { getFilteredRecommendations } from "@/utils/recommendationsLogic";
  
  export default {
    data() {
      return {
        formData: {
          employmentType: [],
          language: [],
          countryPreference: "",
          requiresVisaSponsorship: false,
          familyFriendly: false,
          costOfLiving: 2,
          climate: "",
          healthcareQuality: 3,
          safetyLevel: 3,
          incomeLevel: 3,
        },
        languages: ["English", "Spanish", "French", "German", "Dutch", "Mandarin", "Japanese"],
        countries: ["Netherlands", "Canada", "Australia", "New Zealand", "Germany", "Singapore"],
        recommendations: []
      };
    },
    methods: {
      handleFormSubmit() {
        // Use the function from recommendationsLogic.js to filter based on form data
        this.recommendations = getFilteredRecommendations(this.formData);
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
  
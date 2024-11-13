import axios from 'axios';

const apiClient = axios.create({
  baseURL: 'https://api.example.com',  // Replace with actual API URL
  headers: {
    'Content-Type': 'application/json',
  },
});

export default {
  fetchOpportunities() {
    return apiClient.get('/opportunities');
  },
  submitApplication(data) {
    return apiClient.post('/applications', data);
  },
};

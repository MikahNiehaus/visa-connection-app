// src/utils/recommendationsLogic.js

export function getFilteredRecommendations(formData) {
    const mockRecommendations = [
      {
        name: "Netherlands",
        language: "English, Dutch",
        costOfLiving: "High",
        climate: "Mild",
        visaInfo: "Allows work visas and remote work options.",
      },
      // Additional mock data...
    ];
  
    // Filtering logic based on formData
    return mockRecommendations.filter((country) => {
      const matchesEmployment = formData.employmentType.includes("Remote")
        ? country.visaInfo.includes("remote")
        : true;
      const matchesLanguage = formData.language.some((lang) => country.language.includes(lang));
      const matchesClimate = country.climate === formData.climate || !formData.climate;
      // Additional conditions can be added here.
      return matchesEmployment && matchesLanguage && matchesClimate;
    });
  }
  
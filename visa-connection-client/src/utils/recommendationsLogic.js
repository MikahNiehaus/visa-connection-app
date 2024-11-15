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
      {
        name: "Canada",
        language: "English, French",
        costOfLiving: "Medium",
        climate: "Cold",
        visaInfo: "Provides options for remote and on-site work visas."
      },
      {
        name: "Australia",
        language: "English",
        costOfLiving: "Medium",
        climate: "Warm",
        visaInfo: "Supports both remote and on-site work visas."
      }
    ];
  
    return mockRecommendations.filter((country) => {
      const matchesEmployment = formData.employmentType.includes("Remote")
        ? country.visaInfo.includes("remote")
        : true;
      const matchesLanguage = formData.language.some((lang) => country.language.includes(lang));
      const matchesClimate = country.climate === formData.climate || !formData.climate;
      return matchesEmployment && matchesLanguage && matchesClimate;
    });
  }
  
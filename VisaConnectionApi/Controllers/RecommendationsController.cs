using Microsoft.AspNetCore.Mvc;
using VisaConnectionApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace VisaConnectionApi.Controllers
{
    [ApiController]
    [Route("api/recommendations")]
    public class RecommendationController : ControllerBase
    {
        private static List<CountryRecommendation> Recommendations = new List<CountryRecommendation>
        {
            new CountryRecommendation { Id = 1, Name = "Netherlands", Language = "English, Dutch", CostOfLiving = "High", Climate = "Mild", VisaInfo = "Work visas and remote options available." },
            new CountryRecommendation { Id = 2, Name = "Canada", Language = "English, French", CostOfLiving = "Medium", Climate = "Cold", VisaInfo = "On-site and remote work visas supported." },
            new CountryRecommendation { Id = 3, Name = "Germany", Language = "German, English", CostOfLiving = "High", Climate = "Mild", VisaInfo = "Offers various work visa options." }
        };

        [HttpPost("get-recommendations")]
        public IActionResult GetRecommendations([FromBody] UserPreferences preferences)
        {
            var filteredRecommendations = Recommendations.AsQueryable();

            if (preferences.Language.Any())
            {
                filteredRecommendations = filteredRecommendations
                    .Where(r => preferences.Language.Any(lang => r.Language.Contains(lang)));
            }

            if (preferences.CountryPreferences.Any())
            {
                filteredRecommendations = filteredRecommendations
                    .Where(r => preferences.CountryPreferences.Contains(r.Name));
            }

            if (preferences.CostOfLiving != 0)
            {
                var cost = preferences.CostOfLiving == 1 ? "Low" : preferences.CostOfLiving == 2 ? "Medium" : "High";
                filteredRecommendations = filteredRecommendations.Where(r => r.CostOfLiving == cost);
            }

            if (!string.IsNullOrEmpty(preferences.Climate))
            {
                filteredRecommendations = filteredRecommendations.Where(r => r.Climate == preferences.Climate);
            }

            return Ok(filteredRecommendations.ToList());
        }
    }
}

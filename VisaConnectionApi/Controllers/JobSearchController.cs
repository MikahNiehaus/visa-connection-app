using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VisaConnectionApi.Models;

namespace VisaConnectionApi.Controllers
{
    [ApiController]
    [Route("api/jobs")]
    public class JobSearchController : ControllerBase
    {
        private static List<Job> Jobs = new List<Job>
        {
            new Job { Id = 1, Title = "Software Engineer", Company = "TechCorp", Location = "Berlin, Germany", Description = "Develop web applications with a focus on performance." },
            new Job { Id = 2, Title = "Data Scientist", Company = "DataX", Location = "Paris, France", Description = "Analyze data and build predictive models." },
            new Job { Id = 3, Title = "Marketing Specialist", Company = "GlobalAds", Location = "Amsterdam, Netherlands", Description = "Manage digital marketing campaigns." },
            new Job { Id = 4, Title = "Project Manager", Company = "BizSolutions", Location = "Rome, Italy", Description = "Coordinate project activities and ensure timely delivery." }
        };

        [HttpGet("search")]
        public IActionResult SearchJobs(string title = "", string location = "", string country = "")
        {
            var filteredJobs = Jobs.AsQueryable();

            if (!string.IsNullOrEmpty(title))
            {
                filteredJobs = filteredJobs.Where(job => job.Title.Contains(title, System.StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(location))
            {
                filteredJobs = filteredJobs.Where(job => job.Location.Contains(location, System.StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(country))
            {
                filteredJobs = filteredJobs.Where(job => job.Location.Contains(country, System.StringComparison.OrdinalIgnoreCase));
            }

            return Ok(filteredJobs.ToList());
        }
    }
}

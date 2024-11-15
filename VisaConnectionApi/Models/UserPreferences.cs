// Models/UserPreferences.cs
using System.Collections.Generic;

namespace VisaConnectionApi.Models
{
    public class UserPreferences
    {
        public List<string> EmploymentType { get; set; } = new List<string>();
        public List<string> Language { get; set; } = new List<string>();
        public List<string> CountryPreferences { get; set; } = new List<string>();
        public int CostOfLiving { get; set; }
        public string Climate { get; set; } = string.Empty;
    }
}

// Models/Job.cs
namespace VisaConnectionApi.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty; // Default value to avoid warning
        public string Company { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty; // Or make nullable: string? Location { get; set; }
        public string Description { get; set; } = string.Empty; // Or make nullable: string? Description { get; set; }
    }
}

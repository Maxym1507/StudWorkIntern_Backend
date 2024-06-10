namespace StudWorkIntern_Backend.Models
{
    public class JobPosting
    {
        public int JobPostingId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public int EmployerId { get; set; }
    }

}

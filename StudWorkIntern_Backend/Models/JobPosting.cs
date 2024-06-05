namespace StudWorkIntern_Backend.Models
{
    public class JobPosting
    {
        public int JobPostingId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal Salary { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int EmployerId { get; set; }
        public Employer Employer { get; set; }
        public ICollection<Application> Applications { get; set; }
    }

}

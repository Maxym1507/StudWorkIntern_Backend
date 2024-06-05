namespace StudWorkIntern_Backend.Models
{
    public class Employer
    {
        public int EmployerId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhoneNumber { get; set; }
        public ICollection<JobPosting> JobPostings { get; set; }
        public ICollection<Internship> Internships { get; set; }
    }

}

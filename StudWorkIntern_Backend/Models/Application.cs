namespace StudWorkIntern_Backend.Models
{
    public class Application
    {
        public int ApplicationId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int? JobPostingId { get; set; }
        public JobPosting JobPosting { get; set; }
        public int? InternshipId { get; set; }
        public Internship Internship { get; set; }
    }

}

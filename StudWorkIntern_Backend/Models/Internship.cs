namespace StudWorkIntern_Backend.Models
{
    public class Internship
    {
        public int InternshipId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EmployerId { get; set; }
        public Employer Employer { get; set; }
        public ICollection<Application>? Applications { get; set; }
    }

}

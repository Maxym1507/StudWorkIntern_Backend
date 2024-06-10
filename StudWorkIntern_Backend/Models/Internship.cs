namespace StudWorkIntern_Backend.Models
{
    public class Internship
    {
        public int InternshipId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EmployerId { get; set; }
    }

}

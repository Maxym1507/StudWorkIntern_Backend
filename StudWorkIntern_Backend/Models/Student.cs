using static System.Net.Mime.MediaTypeNames;

namespace StudWorkIntern_Backend.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ResumeUrl { get; set; }
        public ICollection<Application>? Applications { get; set; }
    }
}

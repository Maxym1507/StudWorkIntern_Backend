using Microsoft.EntityFrameworkCore;

namespace StudWorkIntern_Backend.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<JobPosting> JobPostings { get; set; }
        public DbSet<Internship> Internships { get; set; }
        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Зв'язок між Student і Application
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Applications)
                .WithOne(a => a.Student)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Зв'язок між Employer і JobPosting
            modelBuilder.Entity<Employer>()
                .HasMany(e => e.JobPostings)
                .WithOne(jp => jp.Employer)
                .HasForeignKey(jp => jp.EmployerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Зв'язок між Employer і Internship
            modelBuilder.Entity<Employer>()
                .HasMany(e => e.Internships)
                .WithOne(i => i.Employer)
                .HasForeignKey(i => i.EmployerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Зв'язок між JobPosting і Application
            modelBuilder.Entity<JobPosting>()
                .HasMany(jp => jp.Applications)
                .WithOne(a => a.JobPosting)
                .HasForeignKey(a => a.JobPostingId)
                .OnDelete(DeleteBehavior.NoAction); // Змінено

            // Зв'язок між Internship і Application
            modelBuilder.Entity<Internship>()
                .HasMany(i => i.Applications)
                .WithOne(a => a.Internship)
                .HasForeignKey(a => a.InternshipId)
                .OnDelete(DeleteBehavior.NoAction); // Змінено
        }

    }

}

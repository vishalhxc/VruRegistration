using VruRegistrationApi.Models;
using Microsoft.EntityFrameworkCore;

namespace VruRegistrationApi.Data
{
    public class VruRegistrationDbContext : DbContext
    {
        public VruRegistrationDbContext(DbContextOptions<VruRegistrationDbContext> options) : base(options)
        { 
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
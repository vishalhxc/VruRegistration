using System.ComponentModel.DataAnnotations;

namespace VruRegistrationApi.Models
{
    public class EnrollmentDto
    {
        [Required]
        public int EnrollmentId { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int CourseId { get; set; }
    }
}

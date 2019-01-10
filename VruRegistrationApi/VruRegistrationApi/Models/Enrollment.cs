using System.ComponentModel.DataAnnotations;

namespace VruRegistrationApi.Models
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Student Student { get; set; }

        [Required]
        public Course Course { get; set; }
    }
}

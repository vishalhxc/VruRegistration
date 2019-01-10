using System;
using System.ComponentModel.DataAnnotations;

namespace VruRegistrationApi.Models
{
    public class Course
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public Instructor Instructor { get; set; }

        [Required]
        public Semester Semester { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [Required]
        [StringLength(5)]
        public string Schedule { get; set; }

        [Required]
        [Range(1,5)]
        public int Credit { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace VruRegistrationApi.Models
{
    public class Semester
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}

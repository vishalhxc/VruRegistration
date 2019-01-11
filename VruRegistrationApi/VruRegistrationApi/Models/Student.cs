using System;
using System.ComponentModel.DataAnnotations;

namespace VruRegistrationApi.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName is required.")]
        [StringLength(50, ErrorMessage = "FirstName is limited to 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required.")]
        [StringLength(50, ErrorMessage = "LastName is limited to 50 characters.")]
        public string LastName { get; set; }

        [StringLength(50, ErrorMessage = "MiddleName is limited to 50 characters.")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "BirthDate must be a valid date.")]
        public DateTime BirthDate { get; set; }
    }
}

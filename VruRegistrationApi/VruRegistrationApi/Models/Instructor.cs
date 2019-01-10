﻿using System;
using System.ComponentModel.DataAnnotations;

namespace VruRegistrationApi.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public string Biography { get; set; }

        public int YearsExperience { get; set; }
    }
}
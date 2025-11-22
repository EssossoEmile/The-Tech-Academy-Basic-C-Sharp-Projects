using System;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstStudent
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime EnrollmentDate { get; set; }
    }
}

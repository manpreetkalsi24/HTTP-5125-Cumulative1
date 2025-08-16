using System.ComponentModel.DataAnnotations;

namespace SchoolMVP.Models
{
    public class Student
    {
        /// <summary>
        /// Represents a student in the school database.
        /// </summary>
        
        [Required]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string? StudentFname { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string? StudentLname { get; set; }

        [Required(ErrorMessage = "Student number is required.")]
        public string? StudentNumber { get; set; }

        [Required(ErrorMessage = "Enrollment date is required.")]
        public DateTime EnrolDate { get; set; }

    }
}

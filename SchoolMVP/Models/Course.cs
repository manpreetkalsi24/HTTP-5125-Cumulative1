using System.ComponentModel.DataAnnotations;

namespace SchoolMVP.Models
{
    public class Course
    {
        /// <summary>
        /// Represents a course offered at the school.
        /// </summary>
        [Required]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course Code is required.")]
        public string? CourseCode { get; set; }

        [Required(ErrorMessage = "Course name is required.")]
        public string? CourseName { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required.")]
        public DateTime FinishDate { get; set; }
        public long TeacherId { get; set; }
         
    }
}

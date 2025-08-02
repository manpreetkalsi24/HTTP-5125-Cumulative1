using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolMVP.Models
{

    /// <summary>
    /// Represents the details of a teacher from the database.
    /// </summary>
    public class Teacher
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Employee number is required.")]
        public string? EmpNumber { get; set; }

        [Required(ErrorMessage = "Hire date is required.")]
        public DateTime HireDate { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        public decimal Salary { get; set; }

        public string? TeacherWorkPhone { get; set; }

    }
}

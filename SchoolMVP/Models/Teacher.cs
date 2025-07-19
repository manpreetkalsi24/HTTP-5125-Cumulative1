using System;

namespace SchoolMVP.Models
{

    /// <summary>
    /// Represents the details of a teacher from the database.
    /// </summary>
    public class Teacher
    {

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmpNumber { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        
    }
}

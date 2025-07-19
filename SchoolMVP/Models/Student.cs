namespace SchoolMVP.Models
{
    public class Student
    {
        /// <summary>
        /// Represents a student in the school database.
        /// </summary>
        public int StudentId { get; set; }
        public string? StudentFname { get; set; }
        public string? StudentLname { get; set; }
        public string? StudentNumber { get; set; }
        public DateTime EnrolDate { get; set; }

    }
}

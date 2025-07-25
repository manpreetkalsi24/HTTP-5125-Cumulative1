﻿namespace SchoolMVP.Models
{
    public class Course
    {
        /// <summary>
        /// Represents a course offered at the school.
        /// </summary>
        public int CourseId { get; set; }
        public string? CourseCode { get; set; }
        public string? CourseName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public long TeacherId { get; set; }
         
    }
}

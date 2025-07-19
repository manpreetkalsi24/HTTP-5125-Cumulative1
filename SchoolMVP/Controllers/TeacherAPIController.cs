using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolMVP.Models;
namespace SchoolMVP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherAPIController : ControllerBase
    {

        private SchoolDbContext _context = new SchoolDbContext();

        /// <summary>
        /// This method should connect with database and extract teachers information as JSON
        /// </summary>
        /// <returns>
        /// It will return the details of all the teachers
        /// </returns>
        /// <example>
        /// *I am just providing one teacher detail because it could be too long.
        /// GET: api/TeacherAPI -> [
        /// {
        ///  "id": 1,
        ///  "firstName": "Alexander",
        ///  "lastName": "Bennett",
        ///  "empNumber": "T378",
        ///  "hireDate": "2016-08-05T00:00:00",
        ///  "salary": 55.3
        /// } ]
        /// </example>
        
        [HttpGet("Teachers")]
        public ActionResult<IEnumerable<Teacher>> GetAllTeachers()
        {

            var teachers = _context.GetAllTeachers();
            return Ok(teachers);
        }

        /// <summary>
        /// This method would connect with the database and extract information of a single teacher by ID as JSON
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a single teacher by ID</returns>
        /// <example>
        /// GET -> api/TeacherAPI/4 ->
        /// {
        ///  "id": 4,
        ///  "firstName": "Lauren",
        ///  "lastName": "Smith",
        ///  "empNumber": "T385",
        ///  "hireDate": "2014-06-22T00:00:00",
        ///  "salary": 74.2
        /// }
        /// </example>
        
        [HttpGet("teacher/{id}")]
        public ActionResult<Teacher> GetTeacherById(int id)
        {
            var teacher = _context.GetTeacherById(id);
            if (teacher == null)
                return NotFound(new
                {
                    message = $"Teacher with ID {id} is not found",
                    status = 404
                });

            return Ok(teacher);
        }

        /// <summary>
        /// This method should connect with database and extract students information as JSON
        /// </summary>
        /// <returns>
        /// It will return the details of all the students
        /// </returns>
        /// <example>
        /// [
        ///      {
        ///       "studentId": 1,
        ///        "studentFname": "Sarah",
        ///        "studentLname": "Valdez",
        ///        "studentNumber": "N1678",
        ///        "enrolDate": "2018-06-18T00:00:00"
        ///      },
        ///      {
        ///        "studentId": 2,
        ///        "studentFname": "Jennifer",
        ///        "studentLname": "Faulkner",
        ///        "studentNumber": "N1679",
        ///        "enrolDate": "2018-08-02T00:00:00"
        ///      }
        ///  ]
        /// </example>

        [HttpGet("Students")]

        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            var students = _context.GetAllStudents();
            return Ok(students);
        }


        /// <summary>
        /// This method should connect with database and extract courses information as JSON
        /// </summary>
        /// <returns>
        /// It will return the details of all the courses
        /// </returns>
        /// <example>
        /// [
        ///    {
        ///    "courseId": 1,
        ///    "courseCode": "http5101",
        ///    "courseName": "Web Application Development",
        ///    "startDate": "2018-09-04T00:00:00",
        ///    "finishDate": "2018-12-14T00:00:00",
        ///    "teacherId": 1
        ///    },
        ///    {
        ///    "courseId": 2,
        ///    "courseCode": "http5102",
        ///    "courseName": "Project Management",
        ///    "startDate": "2018-09-04T00:00:00",
        ///    "finishDate": "2018-12-14T00:00:00",
        ///    "teacherId": 2
        ///    }
        /// ]
        /// </example>

        [HttpGet("Courses")]

        public ActionResult<IEnumerable<Student>> GetAllCourses()
        {
            var courses = _context.GetAllCourses();
            return Ok(courses);
        }


    }
}



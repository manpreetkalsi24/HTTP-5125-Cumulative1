using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using SchoolMVP.Models;
using System;
using MySql.Data.MySqlClient;
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
        /// NOTE:- *I am just providing one teacher detail because it could be too long.
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
        //public ActionResult<IEnumerable<Teacher>> GetAllTeachers()
        //{

        //    var teachers = _context.GetAllTeachers();
        //    return Ok(teachers);
        //}

        public List<Teacher> GetAllTeachers()
        {

            var teachers = _context.GetAllTeachers();
            return (teachers);
        }

        /// <summary>
        /// This method would connect with the database and extract information of a single teacher by ID as JSON
        /// </summary>
        /// <param name="id">id of a teacher</param>
        /// <returns>Returns a single teacher by ID</returns>
        /// <example>
        /// GET -> api/TeacherAPI/4 ->
        /// {
        ///  "id": 4,
        ///  "firstName": "Lauren",
        ///  "lastName": "Smith",
        ///  "empNumber": "T385",
        ///  "hireDate": "2014-06-22T00:00:00",
        ///  "salary": 74.2,
        ///  "TeacherWorkPhone" : "4537738"
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
        /// it will add new teacher details in the database
        /// </summary>
        /// <example>
        /// POST -> /teacherpage/new
        /// </example>
        /// <param name="teacher"></param>
        /// <returns>it will redirect to teacher list page where all the teachers are shown</returns>
       
        [HttpPost(template: "AddTeacher")]

        public int AddTeacher([FromBody] Teacher teacher)
        {
            //Validate the Hire Date- it cant be in future
            if (teacher.HireDate > DateTime.Today)
            {
                return 0; // Invalid hire date – don’t insert
            }

            // 'using' will close the connection after the code executes
            using (MySqlConnection Connection = SchoolDbContext.AccessDatabase())
            {
                //open database connection
                Connection.Open();

                //Establish a new command (query) for our database
                MySqlCommand Command = Connection.CreateCommand();
                Command.CommandText = "insert into teachers (teacherfname,teacherlname,employeenumber,hiredate,salary,teacherworkphone) values (@teacherfname,@teacherlname,@employeenumber,@hiredate,@salary,@teacherworkphone)";
                Command.Parameters.AddWithValue("@teacherfname", teacher.FirstName);
                Command.Parameters.AddWithValue("@teacherlname", teacher.LastName);
                Command.Parameters.AddWithValue("@employeenumber", teacher.EmpNumber);
                Command.Parameters.AddWithValue("@hiredate", teacher.HireDate);
                Command.Parameters.AddWithValue("@salary", teacher.Salary);
                Command.Parameters.AddWithValue("@teacherworkphone", teacher.TeacherWorkPhone);

                int rowsAffected = Command.ExecuteNonQuery();


                if (rowsAffected > 0)
                {
                    return (int)Command.LastInsertedId; // just return the ID

                }
                else
                {
                    return 0; // if failed
                }
            }
        }

        /// <summary>
        /// Deletes a teacher from the database
        /// </summary>
        /// <param name="teacherId">Primary key of the teacher to delete</param>
        /// <example>
        /// DELETE: api/teacherAPI/DeleteTeacher -> 11
        /// </example>
        /// <returns>a message with the teacher Id that is deleted after delete operation.</returns>

        [HttpDelete(template: "DeleteTeacher/{TeacherId}")]
        public int DeleteTeacher(int teacherId)
        {
            // 'using' will close the connection after the code executes
            using (MySqlConnection Connection = SchoolDbContext.AccessDatabase())
            {
                Connection.Open();
                //Establish a new command (query) for our database
                MySqlCommand Command = Connection.CreateCommand();

                //query to delete teacher from the database 

                Command.CommandText = "delete from teachers where teacherId=@Id";
                Command.Parameters.AddWithValue("@Id", teacherId);
                int rowsAffected = Command.ExecuteNonQuery();

                //condition to check if any rows in database affected or not 
                if (rowsAffected > 0)
                {

                    //if affected the give this message
                    return (teacherId);
                }
                else
                {
                    //if not then give this message
                    return 0;
                }

            }

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
        /// This method would connect with the database and extract information of a single student by ID as JSON
        /// </summary>
        /// <param name="id">id of the particular student</param>
        /// <returns>Returns a single student by ID</returns>
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

        [HttpGet("student/{id}")]
        public ActionResult<Teacher> GetStudentById(int id)
        {
            var student = _context.GetStudentById(id);
            if (student == null)
                return NotFound(new
                {
                    message = $"Student with ID {id} is not found",
                    status = 404
                });

            return Ok(student);
        }


        /// <summary>
        /// Adds a student into the database
        /// </summary>
        /// <param name="student">student Object</param>
        /// <example>
        /// POST: api/StudentPage/New
        /// Headers: Content-Type: application/json
        /// Request Body:
        /// {
        ///      "studentId": 2,
        ///      "studentFname": "Jennifer",
        ///      "studentLname": "Faulkner",
        ///      "studentNumber": "N1679",
        ///      "enrolDate": "2018-08-02T00:00:00"
        ///   } -> 2
        /// </example>
        /// <returns>The inserted student Id from the database if successful. 0 if Unsuccessful</returns>
        

       
        //API for students

        [HttpPost(template: "AddStudent")]

        public int AddStudent([FromBody] Student student)
        {

            // 'using' will close the connection after the code executes
            using (MySqlConnection Connection = SchoolDbContext.AccessDatabase())
            {
                //open database connection
                Connection.Open();

                //Establish a new command (query) for our database
                MySqlCommand Command = Connection.CreateCommand();
                Command.CommandText = "insert into students (studentfname,studentlname,studentnumber,enroldate) values (@studentfname,@studentlname,@studentnumber,@enroldate)";
                Command.Parameters.AddWithValue("@studentfname", student.StudentFname);
                Command.Parameters.AddWithValue("@studentlname", student.StudentLname);
                Command.Parameters.AddWithValue("@studentnumber",student.StudentNumber);
                Command.Parameters.AddWithValue("@enroldate", student.EnrolDate);
               
                int rowsAffected = Command.ExecuteNonQuery();


                if (rowsAffected > 0)
                {
                    return (int)Command.LastInsertedId; // just return the ID

                }
                else
                {
                    return 0; // if failed
                }
            }
        }

        /// <summary>
        /// Deletes a student from the database
        /// </summary>
        /// <param name="studentId">Primary key of the student to delete</param>
        /// <example>
        /// DELETE: api/teacherAPI/DeleteStudent -> 11
        /// </example>
        /// <returns>a message with the student Id that is deleted after delete operation.</returns>

        [HttpDelete(template: "DeleteStudent/{StudentId}")]
        public int DeleteStudent(int studentId)
        {
            // 'using' will close the connection after the code executes
            using (MySqlConnection Connection = SchoolDbContext.AccessDatabase())
            {
                Connection.Open();
                //Establish a new command (query) for our database
                MySqlCommand Command = Connection.CreateCommand();

                //query to delete student from the database 

                Command.CommandText = "delete from students where studentId=@Id";
                Command.Parameters.AddWithValue("@Id", studentId);
                int rowsAffected = Command.ExecuteNonQuery();

                //condition to check if any rows in database affected or not 
                if (rowsAffected > 0)
                {

                    //if affected the give this message
                    return (studentId);
                }
                else
                {
                    //if not then give this message
                    return 0;
                }

            }

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

        /// <summary>
        /// This method would connect with the database and extract information of a single course by ID as JSON
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a single course by ID</returns>
        /// <example>
        /// GET -> api/TeacherAPI/course/4 ->
        /// {
        /// "courseId": 2,
        ///  "courseCode": "http5102",
        ///  "courseName": "Project Management",
        ///  "startDate": "2018-09-04T00:00:00",
        ///  "finishDate": "2018-12-14T00:00:00",
        ///  "teacherId": 2
        /// }
        /// </example>

        [HttpGet("course/{id}")]
        public ActionResult<Teacher> GetCourseById(int id)
        {
            var course = _context.GetCourseById(id);
            if (course == null)
                return NotFound(new
                {
                    message = $"Course with ID {id} is not found",
                    status = 404
                });

            return Ok(course);
        }

        /// <summary>
        /// Adds a course to the database
        /// </summary>
        /// <param name="course">Teacher Object</param>
        /// <example>
        /// POST: api/TeacherAPI/CoursePage/new
        /// Headers: Content-Type: application/json
        /// Request Body:
        /// {
        ///  "courseId": 14,
        ///  "courseCode": "http5102",
        ///  "courseName": "Product Management",
        ///  "startDate": "2018-09-04T00:00:00",
        ///  "finishDate": "2018-12-14T00:00:00",
        ///  "teacherId": 2
        /// } -> 14
        /// </example>
        /// <returns>The inserted course Id from the database if successful. 0 if Unsuccessful</returns>



        //API for courses

        [HttpPost(template: "AddCourse")]

        public int AddCourse([FromBody] Course course)
        {

            // 'using' will close the connection after the code executes
            using (MySqlConnection Connection = SchoolDbContext.AccessDatabase())
            {
                //open database connection
                Connection.Open();

                //Establish a new command (query) for our database
                MySqlCommand Command = Connection.CreateCommand();
                Command.CommandText = "insert into courses (coursecode,coursename,startdate,finishdate,teacherid) values (@coursecode,@coursename,@startdate,@finishdate,@teacherid)";
                Command.Parameters.AddWithValue("@coursecode", course.CourseCode);
                Command.Parameters.AddWithValue("@coursename", course.CourseName);
                Command.Parameters.AddWithValue("@startdate", course.StartDate);
                Command.Parameters.AddWithValue("@finishdate", course.FinishDate);
                Command.Parameters.AddWithValue("@teacherid", course.TeacherId);

                int rowsAffected = Command.ExecuteNonQuery();


                if (rowsAffected > 0)
                {
                    return (int)Command.LastInsertedId; // just return the ID

                }
                else
                {
                    return 0; // if failed
                }
            }
        }

        /// <summary>
        /// Deletes a course from the database
        /// </summary>
        /// <param name="courseId">Primary key of a course to delete</param>
        /// <example>
        /// DELETE: api/teacherAPI/DeleteCourse -> 11
        /// </example>
        /// <returns>a message with the course Id that is deleted after delete operation.</returns>

        [HttpDelete(template: "DeleteCourse/{courseId}")]
        public int DeleteCourse(int courseId)
        {
            // 'using' will close the connection after the code executes
            using (MySqlConnection Connection = SchoolDbContext.AccessDatabase())
            {
                Connection.Open();
                //Establish a new command (query) for our database
                MySqlCommand Command = Connection.CreateCommand();

                //query to delete student from the database 

                Command.CommandText = "delete from courses where courseid=@Id";
                Command.Parameters.AddWithValue("@Id", courseId);
                int rowsAffected = Command.ExecuteNonQuery();

                //condition to check if any rows in database affected or not 
                if (rowsAffected > 0)
                {

                    //if affected the give this message
                    return (courseId);
                }
                else
                {
                    //if not then give this message
                    return 0;
                }

            }

        }
    }
}



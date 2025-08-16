using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System.Collections.Generic;


namespace SchoolMVP.Models
{
    public class SchoolDbContext
    {

        //secret database properties
        public static string User { get { return "root"; } }
        public static string Password { get { return ""; } }
        public static string Database { get { return "school_mvp"; } }
        public static string Server { get { return "localhost"; } }
        public static string Port { get { return "3306"; } }

        //connection string 
        public static string ConnectionString
        {
            get
            {
                return $"server={Server};user={User};password={Password};database={Database};port={Port}";

            }

        }

        public static MySqlConnection AccessDatabase()
        {
            return new MySqlConnection(ConnectionString);
        }


     //Method for getting details of all the teachers
        public List<Teacher> GetAllTeachers()
        {
            //create an empty list for teachers detail
            List<Teacher> teachers = new List<Teacher>();

            //use the AccessDatabase function made for connecting with database
            MySqlConnection Connection = SchoolDbContext.AccessDatabase();

            //open the database connection
            Connection.Open();

            //Sql query for getting all details of teachers
            string query = "SELECT * FROM teachers";

            // Create command
            MySqlCommand Command = new MySqlCommand(query, Connection);

            //run the query against database
            //get the response from a databse as a Result set
            MySqlDataReader ResultSet = Command.ExecuteReader();

            //loop through the results to get info of teachers

            while (ResultSet.Read())
            {
                //creation of an object by using the class to access the database fields
                Teacher newTeacher = new Teacher();

                newTeacher.Id = Convert.ToInt32(ResultSet["teacherid"]);
                newTeacher.FirstName = ResultSet["teacherfname"].ToString();
                newTeacher.LastName = ResultSet["teacherlname"].ToString() ;
                newTeacher.EmpNumber = ResultSet["employeenumber"].ToString();
                newTeacher.HireDate = Convert.ToDateTime(ResultSet["hiredate"]);
                newTeacher.Salary = Convert.ToDecimal(ResultSet["salary"]);
                newTeacher.TeacherWorkPhone = ResultSet["teacherworkphone"].ToString();

                teachers.Add(newTeacher);
            }
            //close the dataset
            ResultSet.Close();
            //close the database connection
            Connection.Close();

            //return the list
            return teachers;
        }

    // Method for getting teacher details by particular id
        public Teacher GetTeacherById(int id)
        {
            //create an empty list for teachers detail
            Teacher? teacher = null;

            //use of the connectionstring made for connecting with database by AccessDatabase function
            MySqlConnection Connection = SchoolDbContext.AccessDatabase();

            //open the database connection
            Connection.Open();

            //Sql query for getting all details of teachers
            string query = "SELECT * FROM teachers WHERE teacherid = @id";

            // Create command
            MySqlCommand Command = new MySqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@id", id);

            //run the query against database
            //get the response from a databse as a Result set
            MySqlDataReader ResultSet = Command.ExecuteReader();

            //loop through the results to get info of teachers

            while (ResultSet.Read())
            {
                Teacher newTeacher = new Teacher();

                newTeacher.Id = Convert.ToInt32(ResultSet["teacherid"]);
                newTeacher.FirstName = ResultSet["teacherfname"].ToString();
                newTeacher.LastName = ResultSet["teacherlname"].ToString();
                newTeacher.EmpNumber = ResultSet["employeenumber"].ToString();
                newTeacher.HireDate = Convert.ToDateTime(ResultSet["hiredate"]);
                newTeacher.Salary = Convert.ToDecimal(ResultSet["salary"]);
                newTeacher.TeacherWorkPhone = ResultSet["teacherworkphone"].ToString();

                teacher = newTeacher;
            }
            //close the dataset
            ResultSet.Close();
            //close the database connection
            Connection.Close();

            //return the list
            return teacher;
        }



    //Method for getting students details
        public List<Student> GetAllStudents()
        {
            //create an empty list object for students detail
            List<Student> students = new List<Student>();

            //use the connectionstring made for connecting with database
            MySqlConnection connection = SchoolDbContext.AccessDatabase();

            //open the database connection
            connection.Open();

            //Mysql query for getting student details
            string query = "Select * FROM students";

            MySqlCommand Command = new MySqlCommand(query, connection);

            //get the response from a databse as a Result set
            MySqlDataReader ResultSet = Command.ExecuteReader();

            //loop through the result set to get details of students

            while (ResultSet.Read())
            {
            
                    Student student = new Student();

                    student.StudentId = Convert.ToInt32(ResultSet["studentid"]);
                    student.StudentFname = ResultSet["studentfname"].ToString();
                    student.StudentLname = ResultSet["studentlname"].ToString();
                    student.StudentNumber = ResultSet["studentnumber"].ToString();
                    student.EnrolDate = Convert.ToDateTime(ResultSet["enroldate"]);

                    students.Add(student);

            }

            //close resultset connection
            ResultSet.Close();

            //close database connection
            connection.Close();

            //return students list
            return students;

        }


        // Method for getting students details by particular id
        public Student GetStudentById(int id)
        {
            //create an empty list for students detail
            Student? student = null;

            //use of the connectionstring made for connecting with database by AccessDatabase function
            MySqlConnection Connection = SchoolDbContext.AccessDatabase();

            //open the database connection
            Connection.Open();

            //Sql query for getting all details of students
            string query = "SELECT * FROM students WHERE studentid = @id";

            // Create command
            MySqlCommand Command = new MySqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@id", id);

            //run the query against database
            //get the response from a databse as a Result set
            MySqlDataReader ResultSet = Command.ExecuteReader();

            //loop through the results to get info of teachers

            while (ResultSet.Read())
            {
                Student newStudent = new Student();

                newStudent.StudentId = Convert.ToInt32(ResultSet["studentid"]);
                newStudent.StudentFname = ResultSet["studentfname"].ToString();
                newStudent.StudentLname = ResultSet["studentlname"].ToString();
                newStudent.StudentNumber = ResultSet["studentnumber"].ToString();
                newStudent.EnrolDate = Convert.ToDateTime(ResultSet["enroldate"]);
                

                student = newStudent;
            }
            //close the dataset
            ResultSet.Close();
            //close the database connection
            Connection.Close();

            //return the list
            return student;
        }


        // Method for getting all course details
        public List<Course> GetAllCourses()
        {
            //create an empty list object for students detail
            List<Course> courses = new List<Course>();

            //use the connectionstring made for connecting with database
            MySqlConnection connection = SchoolDbContext.AccessDatabase();

            //open the database connection
            connection.Open();

            //Mysql query for getting student details
            string query = "Select * FROM courses";

            MySqlCommand Command = new MySqlCommand(query, connection);

            //get the response from a databse as a Result set
            MySqlDataReader ResultSet = Command.ExecuteReader();

            //loop through the result set to get details of students

            while (ResultSet.Read())
            {

                Course course = new Course();

                course.CourseId = Convert.ToInt32(ResultSet["courseid"]);
                course.CourseCode = ResultSet["coursecode"].ToString();
                course.CourseName = ResultSet["coursename"].ToString();
                course.StartDate = Convert.ToDateTime(ResultSet["startdate"]);
                course.FinishDate = Convert.ToDateTime(ResultSet["finishdate"]);
                course.TeacherId = Convert.ToInt64(ResultSet["teacherid"]);

                courses.Add(course);

            }

            //close resultset connection
            ResultSet.Close();

            //close database connection
            connection.Close();

            //return students list
            return courses;

        }

    // method for getting all the courses taught by a particular teacher

        public List<Course> GetCoursesByTeacherId(int teacherId)
        {
            //create list object for storing values
            List<Course> courses = new List<Course>();

            //create sql connection for accessing the database
            MySqlConnection Connection = SchoolDbContext.AccessDatabase();

            //open database connection
            Connection.Open();

            //query for getting database values
            String query = "SELECT * FROM courses WHERE teacherid = @teacherId";

            MySqlCommand Command = new MySqlCommand(query, Connection);

            //send value of teacherId from c# into Sql query
            Command.Parameters.AddWithValue("@teacherId", teacherId);

            MySqlDataReader ResultSet = Command.ExecuteReader();

            while (ResultSet.Read())
            {
                Course course = new Course();
                course.CourseId = Convert.ToInt32(ResultSet["courseid"]);
                course.CourseCode = ResultSet["coursecode"].ToString();
                course.CourseName = ResultSet["coursename"].ToString();
                course.StartDate = Convert.ToDateTime(ResultSet["startdate"]);
                course.FinishDate = Convert.ToDateTime(ResultSet["finishdate"]);
                course.TeacherId = Convert.ToInt64(ResultSet["teacherid"]);

                courses.Add(course);    
            }

            //close the resultset
            ResultSet.Close() ;

            //close databse connection
            Connection.Close();

            //return all courses 
            return courses;
        }


        // Method for getting students details by particular id
        public Course GetCourseById(int id)
        {
            //create an empty list for courses detail
            Course? course = null;

            //use of the connectionstring made for connecting with database by AccessDatabase function
            MySqlConnection Connection = SchoolDbContext.AccessDatabase();

            //open the database connection
            Connection.Open();

            //Sql query for getting all details of students
            string query = "SELECT * FROM courses WHERE courseid = @id";

            // Create command
            MySqlCommand Command = new MySqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@id", id);

            //run the query against database
            //get the response from a databse as a Result set
            MySqlDataReader ResultSet = Command.ExecuteReader();

            //loop through the results to get info of teachers

            while (ResultSet.Read())
            {
                Course newCourse = new Course();

                newCourse.CourseId = Convert.ToInt32(ResultSet["courseid"]);
                newCourse.CourseCode = ResultSet["coursecode"].ToString();
                newCourse.CourseName = ResultSet["coursename"].ToString();
                newCourse.TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                newCourse.StartDate = Convert.ToDateTime(ResultSet["startdate"]);
                newCourse.FinishDate = Convert.ToDateTime(ResultSet["finishdate"]);

                course = newCourse;
            }
            //close the dataset
            ResultSet.Close();
            //close the database connection
            Connection.Close();

            //return the list
            return course;
        }
    }
}

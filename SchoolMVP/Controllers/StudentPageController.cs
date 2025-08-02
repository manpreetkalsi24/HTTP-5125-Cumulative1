using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using SchoolMVP.Models;

namespace SchoolMVP.Controllers
{
    public class StudentPageController : Controller
    {

        private readonly TeacherAPIController _api;

        public StudentPageController(TeacherAPIController api)
        {
            _api = api;
        }

        //method for getting list of all students 
        public IActionResult StudentList()
        {
            SchoolDbContext Context_obj = new SchoolDbContext();
            List<Student> Students = Context_obj.GetAllStudents();
            //condition for checking if any students exists or not
            if (Students == null)
            {
                return NotFound("No Student found.");
            }
            return View("~/Views/Student/StudentList.cshtml", Students);
            
        }


        //method for getting list of all teacher deatils
        //public IActionResult Show(int id)
        //{
        //    SchoolDbContext Context_obj = new SchoolDbContext();
        //    Teacher Teacher = Context_obj.GetTeacherById(id);
        //    if (Teacher == null)
        //    {
        //        return NotFound($"Teacher with ID {id} not found.");
        //    }
        //    return View("~/Views/Teacher/Show.cshtml", Teacher);
        //}


        //method for getting a student by ID
        public IActionResult Show(int id)
        {
            SchoolDbContext Context_obj = new SchoolDbContext();
            Student Student = Context_obj.GetStudentById(id);

            if (Student == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }

            return View("~/Views/student/Show.cshtml", Student);
        }


        // GET : StudentPage/New
        [HttpGet]
        public IActionResult New(int id)
        {
            return View("~/Views/Student/New.cshtml");
        }


        // POST: TeacherPage/Create
        [HttpPost]
        public IActionResult Create(Student NewStudent)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Student/New.cshtml", NewStudent); // Show form again with errors
            }

            int StudentId = _api.AddStudent(NewStudent);

            if (StudentId <= 0)
            {
                ViewBag.ErrorMessage = "Failed to add student.";
                ViewBag.ErrorMessage = "Enrollment date cannot be in the future.";
                return View("~/Views/Student/New.cshtml", NewStudent);
            }

            // redirects to "Show" action on "student" cotroller with id parameter supplied
            return RedirectToAction("Show","StudentPage", new { id = StudentId });
        }


        // GET : StudentPage/DeleteConfirm/{id}
        [HttpGet]
        public IActionResult DeleteConfirm(int id)
        {
            var result = _api.GetStudentById(id);

            if (result.Result is OkObjectResult ok && ok.Value is Student SelectedStudent)
            {
                return View("~/Views/Student/DeleteConfirm.cshtml", SelectedStudent);
            }
            else
            {
                return NotFound("Student not found");
            }

        }

        // POST: StudentPage/Delete/{id}
        [HttpPost]
        public IActionResult Delete(int id)
        {
            int StudentId = _api.DeleteStudent(id);
            // redirects to list action
            return RedirectToAction("StudentList");
        }
    }


}

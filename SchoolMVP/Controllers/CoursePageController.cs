using Microsoft.AspNetCore.Mvc;
using SchoolMVP.Models;

namespace SchoolMVP.Controllers
{
    public class CoursePageController : Controller
    {

        private readonly TeacherAPIController _api;

        public CoursePageController(TeacherAPIController api)
        {
            _api = api;
        }
        //method for getting list of all courses 
        public IActionResult CourseList()
        {
            SchoolDbContext Context_obj = new SchoolDbContext();
            List<Course> Courses = Context_obj.GetAllCourses();
            if (Courses == null)
            {
                return NotFound("No Course found.");
            }
            return View("~/Views/Course/CourseList.cshtml", Courses);
        }


        //method for getting a course by ID
        public IActionResult Show(int id)
        {
            SchoolDbContext Context_obj = new SchoolDbContext();
            Course Course = Context_obj.GetCourseById(id);

            if (Course == null)
            {
                return NotFound($"Course with ID {id} not found.");
            }

            return View("~/Views/course/Show.cshtml", Course);
        }


        // GET : CoursePage/New
        [HttpGet]
        public IActionResult New(int id)
        {

            List<Teacher> teachers = _api.GetAllTeachers(); 


            ViewBag.Teachers = teachers;

            //return View();
            return View("~/Views/Course/New.cshtml");
        }


        // POST: CoursePage/Create
        [HttpPost]
        public IActionResult Create(Course NewCourse)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Course/New.cshtml", NewCourse); // Show form again with errors
            }

            int CourseId = _api.AddCourse(NewCourse);

            if (CourseId <= 0)
            {
                ViewBag.ErrorMessage = "Failed to add course.";
                return View("~/Views/Course/New.cshtml", NewCourse);
            }

            // redirects to "Show" action on "student" cotroller with id parameter supplied
            return RedirectToAction("Show", "CoursePage", new { id = CourseId });
        }


        // GET : CoursePage/DeleteConfirm/{id}
        [HttpGet]
        public IActionResult DeleteConfirm(int id)
        {
            var result = _api.GetCourseById(id);

            if (result.Result is OkObjectResult ok && ok.Value is Course SelectedCourse)
            {
                return View("~/Views/Course/DeleteConfirm.cshtml", SelectedCourse);
            }
            else
            {
                return NotFound("Course not found");
            }

        }

        // POST: CoursePage/Delete/{id}
        [HttpPost]
        public IActionResult Delete(int id)
        {
            int CourseId = _api.DeleteCourse(id);
            // redirects to list action
            return RedirectToAction("CourseList");
        }
    }
}

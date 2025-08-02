using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using SchoolMVP.Models;

namespace SchoolMVP.Controllers
{
    public class TeacherPageController : Controller
    {

        private readonly TeacherAPIController _api;

        public TeacherPageController(TeacherAPIController api)
        {
            _api = api;
        }

        //method for getting list of all teacher details and search feture by hiredate
        public IActionResult List(DateTime? startDate, DateTime? endDate)
        {
            SchoolDbContext Context_obj = new SchoolDbContext();
            List<Teacher> Teachers = Context_obj.GetAllTeachers();
            if (Teachers == null)
            {
                return NotFound("No Teacher found.");
            }

            if (startDate.HasValue && endDate.HasValue)
            {
                Teachers = Teachers.Where(t => t.HireDate >= startDate && t.HireDate <= endDate).ToList();
            }
                
            return View("~/Views/Teacher/List.cshtml", Teachers);
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


        //method for getting a teacher by ID
        public IActionResult Show(int id)
        {
            SchoolDbContext Context_obj = new SchoolDbContext();
            Teacher Teacher = Context_obj.GetTeacherById(id);
            var courses = Context_obj.GetCoursesByTeacherId(id);
           
            if (Teacher == null)
            {
                return NotFound($"Teacher with ID {id} not found.");
            }

            var viewModel = new TeacherCourseViewModel
            {
                Teacher = Teacher,
                Courses = courses
            };

            return View("~/Views/Teacher/Show.cshtml", viewModel);
        }


        // GET : TeacherPage/New
        [HttpGet]
        public IActionResult New(int id)
        {
            return View("~/Views/Teacher/New.cshtml");
        }


        // POST: TeacherPage/Create
        [HttpPost]
        public IActionResult Create(Teacher NewTeacher)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Teacher/New.cshtml", NewTeacher); // Show form again with errors
            }

            int TeacherId = _api.AddTeacher(NewTeacher);

            if (TeacherId <= 0)
            {
                ViewBag.ErrorMessage = "Failed to add teacher.";
                ViewBag.ErrorMessage = "Hire date cannot be in the future.";
                return View("~/Views/Teacher/New.cshtml", NewTeacher);
            }

            // redirects to "Show" action on "Teacher" cotroller with id parameter supplied
            return RedirectToAction("Show", new { id = TeacherId });
        }


        // GET : TeacherPage/DeleteConfirm/{id}
        [HttpGet]
        public IActionResult DeleteConfirm(int id)
        {
            var result = _api.GetTeacherById(id);

            if (result.Result is OkObjectResult ok && ok.Value is Teacher SelectedTeacher)
            {
                return View("~/Views/Teacher/DeleteConfirm.cshtml",SelectedTeacher);
            }
            else
            {
                return NotFound("Teacher not found");
            }
         
        }

        // POST: TeacherPage/Delete/{id}
        [HttpPost]
        public IActionResult Delete(int id)
        {
            int TeacherId = _api.DeleteTeacher(id);
            // redirects to list action
            return RedirectToAction("List");
        }
    }
}

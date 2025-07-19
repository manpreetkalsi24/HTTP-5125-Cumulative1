using Microsoft.AspNetCore.Mvc;
using SchoolMVP.Models;

namespace SchoolMVP.Controllers
{
    public class TeacherPageController : Controller
    {

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

    }
}

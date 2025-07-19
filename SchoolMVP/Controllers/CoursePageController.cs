using Microsoft.AspNetCore.Mvc;
using SchoolMVP.Models;

namespace SchoolMVP.Controllers
{
    public class CoursePageController : Controller
    {
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
    }
}

using Microsoft.AspNetCore.Mvc;
using SchoolMVP.Models;

namespace SchoolMVP.Controllers
{
    public class StudentPageController : Controller
    {
        public IActionResult StudentList()
        {
            SchoolDbContext Context_obj = new SchoolDbContext();
            List<Student> Students = Context_obj.GetAllStudents();
            if (Students == null)
            {
                return NotFound("No Student found.");
            }
            return View("~/Views/Student/StudentList.cshtml", Students);
            
        }
    }
}

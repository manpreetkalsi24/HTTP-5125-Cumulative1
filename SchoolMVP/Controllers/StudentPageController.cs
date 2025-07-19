using Microsoft.AspNetCore.Mvc;
using SchoolMVP.Models;

namespace SchoolMVP.Controllers
{
    public class StudentPageController : Controller
    {
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
    }
}

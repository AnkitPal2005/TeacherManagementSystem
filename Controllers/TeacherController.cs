using Microsoft.AspNetCore.Mvc;
using TeacherManagementSystem.Repositories;
using TeacherManagementSystem.Models;
namespace TeacherManagementSystem.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _teacherRepo;
        public TeacherController(ITeacherRepository teacherRepo)
        {
            _teacherRepo = teacherRepo;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult LoadTeachers()
        {
            var data = _teacherRepo.GetAll();
            return PartialView("_TeacherTable", data);
        }
        public IActionResult LoadForm()
        {
            return PartialView("_TeacherForm", new Teacher());
        }
        [HttpPost]
        public IActionResult AddTeacher(Teacher teacher)
        {
            if (teacher.Id == 0) 
            _teacherRepo.Add(teacher);
            else                 
                _teacherRepo.Update(teacher);
            return Ok();

        }
        [HttpGet]
        public IActionResult LoadEditForm(int id)
        {
            var teacher = _teacherRepo.GetById(id);
            return PartialView("_TeacherForm", teacher);
        }
        [HttpPost]
        public IActionResult Delete(int id) {
            try
            {
                var result = _teacherRepo.Delete(id);
                if (result == 0)
                {
                    return NotFound(new { message = "Teacher not found or already deleted." });
                }
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception (if logger existed)
                return StatusCode(500, new { message = "Error deleting teacher: " + ex.Message });
            }
        }
        public IActionResult TeacherPartial()
        {
            return PartialView("_TeacherIndexPartial");
        }
    }
}

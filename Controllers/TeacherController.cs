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
        [HttpGet]
        public IActionResult LoadForm()
        {
            return PartialView("_TeacherForm", new Teacher());
        }
        [HttpPost]
        public IActionResult AddTeacher(Teacher teacher)
        {
            bool alreadyAssigned = _teacherRepo.IsSubjectAlreadyAssigned(teacher.SubjectId,teacher.Id);
            if (alreadyAssigned)
            {
                return BadRequest("This subject is already assigned to another teacher.");
            }
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
           
                _teacherRepo.Delete(id);
              
                return Ok();
       
        }
    }
}

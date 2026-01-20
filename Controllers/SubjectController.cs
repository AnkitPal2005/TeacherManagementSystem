using Microsoft.AspNetCore.Mvc;
using TeacherManagementSystem.Models;
using TeacherManagementSystem.Repositories;
namespace TeacherManagementSystem.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectRepository _subjectRepository;
        public SubjectController(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        public IActionResult Index()
        {
            var subjects = _subjectRepository.GetAll();
            return View(subjects);
        }
        public IActionResult LoadSubjects()
        {
            var subjects = _subjectRepository.GetAll();
            return PartialView("_SubjectTable", subjects);
        }
        public IActionResult LoadForm()
        {
            return PartialView("_SubjectForm", new Subject());
        }
        public IActionResult EditPartial(int id)
        {
            var subject = _subjectRepository.GetById(id);
            return PartialView("_SubjectForm", subject);
        }
        [HttpPost]
        public IActionResult Create(Subject subject)
        {
            _subjectRepository.Add(subject);
            return Ok();
        }
        [HttpPost]
        public IActionResult Edit(Subject subject)
        {
            _subjectRepository.Update(subject);
            return Ok();

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (_subjectRepository.IsSubjectUsed(id))
            {
                return BadRequest("Cannot delete subject as it is assigned to one or more teachers.");
            }
            _subjectRepository.Delete(id);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetSubjects()
        {
            var subjects = _subjectRepository.GetAll();
            return Json(subjects);
        }


    }
}
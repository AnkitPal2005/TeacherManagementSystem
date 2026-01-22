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
            //var subjects = _subjectRepository.GetAll();
            return View();
        }
        [HttpGet]
        public IActionResult LoadSubjects()
        {
            var subjects = _subjectRepository.GetAll();
            return PartialView("_SubjectTable", subjects);
        }
        [HttpGet]
        public IActionResult LoadForm()
        {
            //return PartialView("_SubjectForm", new Subject());
            return PartialView("_CreateSubjectForm");
        }
        [HttpGet]
        public IActionResult EditPartial(int id)
        {
            var subject = _subjectRepository.GetById(id);
            //return PartialView("_SubjectForm", subject);
            return PartialView("_EditSubjectForm", subject);
        }
        [HttpPost]
        public IActionResult Create(Subject subject)
        {
            if (_subjectRepository.IsDuplicateSubject(subject.Name))
                //return BadRequest("Subject name already exists.");
                return StatusCode(400, "Subject name already exists.");
            _subjectRepository.Add(subject);
            return Ok();
        }
        //("Subject/Edit/{id}")
        [HttpPost]
        public IActionResult Edit(Subject subject)
        {
            var existing = _subjectRepository.GetById(subject.Id);
            if (existing == null)
                return NotFound();

            //subject.Id = id;
            if (_subjectRepository.IsDuplicateSubject(subject.Name, subject.Id))
                return StatusCode(400,"Subject name already exists.");
            _subjectRepository.Update(subject);
            return Ok();

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (_subjectRepository.IsSubjectUsed(id))
            {
                return StatusCode(400,"Cannot delete subject as it is assigned to one or more teachers.");
            }
            _subjectRepository.Delete(id);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAvailableSubjects(int teacherId = 0)
        {
            var subjects = _subjectRepository.GetAvailableSubjects(teacherId);
            return Json(subjects);
        }



    }
}
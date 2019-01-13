using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VruRegistrationApi.Data;
using VruRegistrationApi.Models;

namespace VruRegistrationApi.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IVruRegistrationRepository _repository;

        public StudentController(IVruRegistrationRepository repository)
        {
            _repository = repository;
        }

        #region Student
        [HttpPost]
        public async Task<IActionResult> PostStudent(Student student)
        {
            _repository.AddStudent(student);
            await _repository.SaveAll();
            return CreatedAtAction("GetStudent", new { studentId = student.Id }, student);
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetStudent(int studentId)
        {
            var student = await _repository.GetStudent(studentId);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _repository.GetAllStudents();
            return Ok(students);
        }

        [HttpPut("{studentId}")]
        public async Task<IActionResult> PutStudent(int studentId, Student student)
        {
            if (studentId != student.Id)
            {
                return BadRequest(new { Id = "Id is required and must match request body." });
            }

            if (_repository.UpdateStudent(student) == false)
            {
                return NotFound();
            }

            await _repository.SaveAll();
            return NoContent();
        }

        [HttpPatch("{studentId}")]
        public async Task<IActionResult> PatchStudent(int studentId, Student student)
        {
            if (studentId != student.Id)
            {
                return BadRequest(new { Id = "Id is required and must match request body." });
            }

            if (_repository.UpdateStudent(student) == false)
            {
                return NotFound();
            }

            await _repository.SaveAll();
            return NoContent();
        }

        [HttpDelete("{studentId}")]
        public async Task<ActionResult<Student>> DeleteStudent(int studentId)
        {
            var student = await _repository.GetStudent(studentId);
            if (student == null)
            {
                return NotFound();
            }

            _repository.DeleteStudent(student);
            await _repository.SaveAll();
            return student;
        }
        #endregion

        #region Enrollment
        [HttpPost("{studentId}/courses/{courseId}")]
        public async Task<IActionResult> PostEnrollment(int studentId, int courseId)
        {
            Course course = await _repository.GetCourse(courseId);
            Student student = await _repository.GetStudent(studentId);
            if (course == null || student == null)
            {
                return NotFound();
            }

            Enrollment enrollment = new Enrollment
            {
                Student = student,
                Course = course
            };
            _repository.AddEnrollment(enrollment);
            await _repository.SaveAll();
            return CreatedAtAction("GetEnrollment", new { id = enrollment.Id }, enrollment);
        }

        [HttpGet("{studentId}/courses/{courseId}")]
        public async Task<IActionResult> GetEnrollment(int studentId, int courseId)
        {
            var result = await _repository.GetCourseEnrollmentForStudent(studentId, courseId);
            return Ok(result);
        }

        [HttpGet("{studentId}/courses")]
        public async Task<IActionResult> GetEnrollments(int studentId)
        {
            IEnumerable<Enrollment> result = await _repository.GetAllCourseEnrollmentsForStudent(studentId);
            return (Ok(result));
        }
        #endregion
    }
}

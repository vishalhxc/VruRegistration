using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VruRegistrationApi.Data;
using VruRegistrationApi.Models;

namespace VruRegistrationApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IVruRegistrationRepository _repository;

        public StudentController(IVruRegistrationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _repository.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _repository.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpGet("{studentId}/course")]
        public IActionResult GetEnrollments(int studentId)
        {

            var result =  _repository.GetCoursesByStudent(studentId);
            return (Ok(result));
        }

        [HttpPost]
        public async Task<IActionResult> PostStudent(Student student)
        {
            _repository.AddStudent(student);
            await _repository.SaveAll();
            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id)
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

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchStudent(int id, Student student)
        {
            if (id != student.Id)
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var student = await _repository.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }

            _repository.DeleteStudent(student);
            await _repository.SaveAll();
            return student;
        }
    }
}

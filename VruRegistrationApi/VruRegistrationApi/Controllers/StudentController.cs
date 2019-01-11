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
            return Ok(student);
        }
    }
}

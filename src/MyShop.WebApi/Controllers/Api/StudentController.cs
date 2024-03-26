using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.WebApi.Models;
using System.Collections.Generic; // Import List<T>

namespace MyShop.WebApi.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly List<Student> _students;

        public StudentController()
        {
            // Initialize sample data (for demonstration purposes)
            _students = new List<Student>
            {
                new Student { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PhoneNumber = "1234567890" },
                new Student { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", PhoneNumber = "9876543210" }
            };
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_students);
        }

        [HttpPost]
        public IActionResult Post(Student newStudent)
        {
            if (newStudent == null)
            {
                return BadRequest();
            }

            // Ensure _students is not null before accessing its Count property
            if (_students != null)
            {
                newStudent.Id = _students.Count + 1;
                _students.Add(newStudent);
                return CreatedAtAction(nameof(Get), new { id = newStudent.Id }, newStudent);
            }
            else
            {
                return StatusCode(500, "Internal Server Error: _students is null");
            }
        }
    }
}

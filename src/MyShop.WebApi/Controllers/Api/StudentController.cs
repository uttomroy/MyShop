using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Core.Models;
using MyShop.Core.Services.FileService;
using System.Collections.Generic; // Import List<T>

namespace MyShop.WebApi.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IndexFileService _fileService;

        public StudentController(IndexFileService indexFileService) 
        {
            _fileService = indexFileService;
            // Initialize sample data (for demonstration purposes)

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_fileService.GetStudents());
        }

        [HttpPost]
        public IActionResult Post(Student newStudent)
        {
            if (newStudent == null)
            {
                return BadRequest();
            }
            _fileService.AddStudent(newStudent);
            return Ok();
        }
    }
}

using epita_2025_core_api_001_students.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace epita_2025_core_api_001_students.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public StudentController() { }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(GetStudents());

        }

        private List<Student> GetStudents()
        {
            return new List<Student>()
    {
                new Student() { Id = 1, Name = "John", Email = "john2@test.com", Age = 20, Course = "Computer Science" },
                new Student() { Id = 2, Name = "Jane", Email = "john2@test.com", Age = 21, Course = "Maths" }, 
                new Student() { Id = 3, Name = "Doe", Email = "john2@test.com", Age = 22, Course = "History" }

    };
        }
    }
}

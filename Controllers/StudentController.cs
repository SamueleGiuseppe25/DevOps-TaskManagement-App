using epita_2025_core_api_001_students.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace epita_2025_core_api_001_students.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly AppDbContext _context;

        public StudentController(ILogger<StudentController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }
     

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(GetStudents());

        }

        [HttpPost]
        
        public async Task<IActionResult> Post([FromBody] Student student)
        {

            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return Ok(GetStudents());
        }

        private List<Student> GetStudents()
        {

            return _context.Students.ToList();
    //        return new List<Student>()
    //{
    //            new Student() { Id = 1, Name = "Johnx", Email = "john2@test.com", Age = 20, Course = "Computer Science" },
    //            new Student() { Id = 2, Name = "Janex", Email = "john2@test.com", Age = 21, Course = "Maths" }, 
    //            new Student() { Id = 3, Name = "Doex", Email = "john2@test.com", Age = 22, Course = "History" }

            //};
        }
    }
}

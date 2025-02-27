using epita_2025_core_api_001_students.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace epita_2025_core_api_001_students.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        private readonly AppDbContext _context;

        public TaskController(ILogger<TaskController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: /api/Task
        [HttpGet]
        public IActionResult Get()
        {
            var tasks = _context.Tasks
       .Select(t => new
       {
           t.Id,
           t.Title,
           t.Description,
           DueDate = t.DueDate.ToString("yyyy-MM-dd HH:mm:ss"),
           t.Priority,
           t.Status
       }).ToList();

            return Ok(tasks);
        }

        // POST: /api/Task
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskModel task)
        {
            if (task == null || string.IsNullOrWhiteSpace(task.Title))
            {
                return BadRequest("Task title is required.");
            }

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return Ok(GetTasks());
        }

        private List<TaskModel> GetTasks()
        {
            return _context.Tasks.ToList();
        }
    }
}

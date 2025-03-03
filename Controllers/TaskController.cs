using epita_2025_core_api_001_students.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // ✅ GET: /api/Task → Retrieves all tasks
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tasks = await _context.Tasks
                .Select(t => new
                {
                    t.Id,
                    t.Title,
                    t.Description,
                    DueDate = t.DueDate.ToString("yyyy-MM-dd HH:mm:ss"),
                    t.Priority,
                    t.Status
                })
                .ToListAsync();

            return Ok(tasks);
        }

        // ✅ POST: /api/Task → Adds a new task
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskModel task)
        {
            if (task == null || string.IsNullOrWhiteSpace(task.Title))
            {
                return BadRequest(new { message = "Task title is required." });
            }

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
        }

        // ✅ PUT: /api/Task/{id}/complete → Marks a task as "Completed"
        [HttpPut("{id}/complete")]
        public async Task<IActionResult> CompleteTask(int id)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            if (task == null)
                return NotFound(new { message = "Task not found!" });

            task.Status = "Completed";
            await _context.SaveChangesAsync();
            return Ok(task);
        }

        // ✅ DELETE: /api/Task/{id} → Deletes a task
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            if (task == null)
                return NotFound(new { message = "Task not found!" });

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Task deleted successfully!" });
        }
    }
}

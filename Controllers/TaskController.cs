using epita_2025_core_api_001_students.Models;
using Microsoft.AspNetCore.Mvc;

namespace epita_2025_core_api_001_students.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TaskController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ GET: api/tasks → Ottiene tutti i task
        [HttpGet]
        public IActionResult GetAllTasks()
        {
            return Ok(_context.Tasks.ToList());
        }

        // ✅ GET: api/tasks/{id} → Ottiene un task specifico
        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound(new { message = "Task non trovato!" });
            }
            return Ok(task);
        }

        // ✅ POST: api/tasks → Aggiunge un nuovo task
        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] TaskItem task)
        {
            if (task == null || string.IsNullOrEmpty(task.Title))
                return BadRequest(new { message = "Il titolo del task è obbligatorio!" });

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
        }

        // ✅ PUT: api/tasks/{id} → Aggiorna un task esistente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskItem updatedTask)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return NotFound(new { message = "Task non trovato!" });

            // Aggiorna solo i campi presenti nella richiesta
            if (!string.IsNullOrEmpty(updatedTask.Title))
                task.Title = updatedTask.Title;
            if (!string.IsNullOrEmpty(updatedTask.Description))
                task.Description = updatedTask.Description;

            task.IsCompleted = updatedTask.IsCompleted; // Questo può essere true o false

            await _context.SaveChangesAsync();
            return Ok(task);
        }

        // ✅ DELETE: api/tasks/{id} → Elimina un task
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return NotFound(new { message = "Task non trovato!" });

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Task eliminato con successo!" });
        }
    }
}

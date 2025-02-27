using System;

namespace epita_2025_core_api_001_students.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public required string Title { get; set; }  // Richiesto alla creazione
        public required string Description { get; set; }  // Richiesto alla creazione
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

}

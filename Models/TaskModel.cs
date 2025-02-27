namespace epita_2025_core_api_001_students.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [DataType(DataType.DateTime)] // Ensures full date & time
        public DateTime DueDate { get; set; }

        public string Priority { get; set; }
        public string Status { get; set; }
    }

}

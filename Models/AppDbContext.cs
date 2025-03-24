using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace epita_2025_core_api_001_students.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<TaskModel> Tasks { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }

   
}

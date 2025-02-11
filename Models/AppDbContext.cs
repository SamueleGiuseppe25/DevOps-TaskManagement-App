using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace epita_2025_core_api_001_students.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }

   
}

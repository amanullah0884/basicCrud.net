using BascCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicCrud.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }

        // DbSet properties for your entities
        public DbSet<Student> Students { get; set; }
    }
}

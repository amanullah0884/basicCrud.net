using BascCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicCrud.Models
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }

        // DbSet properties for your entities
        public DbSet<Movie> Movies { get; set; }
    }
}

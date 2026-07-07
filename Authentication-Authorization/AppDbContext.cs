using Microsoft.EntityFrameworkCore;
using MovieManagementSystem.Model;

namespace MovieManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Movie> movie {  get; set; }
        public DbSet<Producer> Producers { get; set; }
    }
}

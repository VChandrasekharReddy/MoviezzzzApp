using MoviezzzzApp.models.entites;
using Microsoft.EntityFrameworkCore;
namespace MoviezzzzApp.config
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<MovieDetails> MovieDetails { get; set; }
        

    }
}

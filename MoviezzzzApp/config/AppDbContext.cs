using Microsoft.EntityFrameworkCore;
namespace MoviezzzzApp.config
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }
}

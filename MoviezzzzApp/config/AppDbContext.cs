using MoviezzzzApp.models.entites;
using Microsoft.EntityFrameworkCore;
namespace MoviezzzzApp.config
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<MovieDetails> MovieDetails { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Role> Role{get;set;}
        public DbSet<Grade> Grade { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one to one Movie <-> MovieDetails
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>()
                .HasOne(md => md.MovieDetails)
                .WithOne(m => m.Movie)
                .HasForeignKey<MovieDetails>(md=>md.MovieId);


            //one to may MovieDetails 1<->*Grade
            modelBuilder.Entity<MovieDetails>()
                .HasOne(md => md.Grade)
                .WithMany(g => g.MovieDetails)
                .HasForeignKey(md => md.GradeId)
                .OnDelete(DeleteBehavior.Cascade); // assuming GradeId is the foreign key in MovieDetails
        }



    }
}

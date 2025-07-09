using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviezzzzApp.config;
using MoviezzzzApp.models.pocos;
using MoviezzzzApp.models.entites;
using Microsoft.EntityFrameworkCore;


namespace MoviezzzzApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MovieController(AppDbContext context)
        {
            _context = context;
        }


        //for geting all the movies from the movie table
        [HttpGet("getallmovies")]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _context.Movie
                .Include(m=>m.MovieDetails)
                    .ThenInclude(p=>p.Cast)
                        .ThenInclude(r=>r.Roles)
                .Include(m=>m.MovieDetails)
                    .ThenInclude(g=>g.Genres)
                .Include(m=>m.MovieDetails)
                    .ThenInclude(g=>g.Grade)
                .ToListAsync();
            return Ok(movies);
        }



        // to create  the moive instance to the move and  the moie details
        [HttpPost("addMovie")]
        public async Task<IActionResult> CreateMovie([FromBody] MovieDao moviedao)
        {
            try
            {
                var moviedetails = new MovieDetails()  //creaating the movie detaild class to add into the movie 
                {
                    Description = moviedao.Description,
                    Duration = moviedao.Duration,
                    Language = moviedao.Language,
                    Country = moviedao.Country,
                    Rating = moviedao.Rating,
                    ReleaseDate = moviedao.ReleaseDate,
                    Cast = await _context.Person.Where(p => moviedao.cast.Contains(p.PersonName)).ToListAsync(),
                    Genres = await _context.Genres.Where(g => moviedao.genrs.Contains(g.GenresName)).ToListAsync(),
                    Grade = await _context.Grade.FirstOrDefaultAsync(g => g.GrageName.Equals(moviedao.grade))
                };



                var movie = new Movie()  // to add the movie 
                {
                    Title = moviedao.Title,
                    imageUrl = moviedao.imageUrl,
                    MovieDetails = moviedetails
                };

                await _context.Movie.AddAsync(movie); //add the data to the table 
                await _context.SaveChangesAsync(); // save changes to the database

                return Ok("also created ray you don !!!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

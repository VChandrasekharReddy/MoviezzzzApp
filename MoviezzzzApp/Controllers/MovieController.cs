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


        //method to send the movie details like name and id to the client and image to redirect to the movie details page to display all the details of the movie
        [HttpGet("getmovies")]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _context.Movie
                .Select(m => new MovieinfoDto { MovieId = m.MovieId, Title = m.Title, imageUrl = m.imageUrl })
                .ToListAsync();
            return Ok(movies);
        }


        //this is the function that will return the movieinfo based on the movie id class
        [HttpPost("movieinfo")]
        public async Task<IActionResult> GetMovieInfoById([FromBody] Movie Movie)
        {
            var response = await _context.Movie.FirstOrDefaultAsync(m=>m.MovieId == Movie.MovieId);
            if( response == null)
            {
                return BadRequest("no matched movies");
            }
            else
            {
                return Ok(response);
            }
        }




        //get the movie by id 
        [HttpPost("moviedetails")]
        public async Task<IActionResult> GetMovieById([FromBody] Movie movie)
        {
            var moviedetails = await _context.MovieDetails
                .Include(m=>m.Grade)
                .Include(m=>m.Genres)
                .Include(m=>m.Cast)
                    .ThenInclude(r=>r.Roles).FirstOrDefaultAsync(m => m.MovieId == movie.MovieId);
            if(moviedetails == null)
            {
                return BadRequest("movie not found ");
            }else
            {
                return Ok(moviedetails);
            }
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
                    Genres = await _context.Genres.Where(g => moviedao.genres.Contains(g.GenresName)).ToListAsync(),
                    Grade = await _context.Grade.FirstOrDefaultAsync(g => g.GradeName.Equals(moviedao.grade))
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
                var inner = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error saving changes: {ex.Message} | Inner: {inner}");
                return BadRequest(ex.Message);
            }

        }
    }
}

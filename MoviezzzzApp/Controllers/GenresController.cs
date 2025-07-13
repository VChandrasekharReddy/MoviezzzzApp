using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviezzzzApp.config;
using MoviezzzzApp.models.entites;

namespace MoviezzzzApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly AppDbContext _context;
        public GenresController(AppDbContext context)
        {
            _context = context;
        }


        // for getting all the ganres to the fe
        [HttpGet("getallgenres")]
        public async Task<IActionResult> ReturnGenres()
        {
            var ganres = await _context.Genres.ToListAsync();
            return Ok(ganres);
        }




        // to create the ganres and store in table Ganres
        [HttpPost("creategenres")]
        public async Task<IActionResult> CreateGenres([FromBody] Genres genres)
        {
            if( await _context.Genres.FirstOrDefaultAsync(p=>p.GenresName == genres.GenresName) == null)
            {
                await _context.Genres.AddAsync(genres);
                await _context.SaveChangesAsync();
                return Ok("saved sucessfully .... dayyyyy");
            }
            else
            {
                return BadRequest("error or already have");
            }

        }


        //this function is for updating hte genres data{
        [HttpPut("updategenres")]
        public async Task<IActionResult> UpdateGenres([FromBody] Genres genres)
        {
            if (genres == null || genres.GenresId == Guid.Empty)
            {
                return BadRequest("Invalid genres data.");
            }
            var existingGenres = await _context.Genres.FindAsync(genres.GenresId);
            if (existingGenres == null)
            {
                return NotFound("Genres not found.");
            }
            existingGenres.GenresName = genres.GenresName;
            _context.Genres.Update(existingGenres);
            await _context.SaveChangesAsync();
            return Ok("Genres updated successfully.");
        }

    }
}

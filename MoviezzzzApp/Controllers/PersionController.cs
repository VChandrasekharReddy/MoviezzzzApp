using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviezzzzApp.config;
using MoviezzzzApp.models.pocos;
using MoviezzzzApp.models.entites;

namespace MoviezzzzApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersionController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PersionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("getallpersons")]
        public async Task<IActionResult> ReturnAllPersons()
        {
            var persons = await _context.Person
                .Include(p => p.Roles)
                .Include(p => p.MovieDetails)
                .ToListAsync();
            return Ok(persons);
        }
        [HttpPost("addperson")]
        public async Task<IActionResult> CreatePerson([FromBody] PersonDao persondao )
        {
            try
            {
                    var roles = await _context.Role.Where(r=> persondao.Roles.Contains(r.RoleName)).ToListAsync();
                Person person = new Person()
                {
                    PersonName = persondao.PersonName,
                    imageUrl = persondao.imageUrl,
                    Biography = persondao.Biography,
                    DateOfBirth = persondao.DateOfBirth,
                    Roles = roles
                };
                await _context.Person.AddAsync(person);
                await _context.SaveChangesAsync();
                return Ok("Person Saved rayyyy");
            }catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

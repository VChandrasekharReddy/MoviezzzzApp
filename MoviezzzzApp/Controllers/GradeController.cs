using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using MoviezzzzApp.config;
using MoviezzzzApp.models.entites;

namespace MoviezzzzApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {

        private readonly AppDbContext _context;
        public GradeController(AppDbContext context)
        {
            _context = context;
        }




        //to get all the grades in for the movies
        [HttpGet("getallgrades")]
        public async Task<IActionResult> ReturnGrades()
        {
            var grades = await _context.Grade.ToListAsync();
            return Ok(grades);

        }




        //to create the grade to the table
        [HttpPost("addgrade")]
        public async Task<IActionResult> CreateGrade([FromBody] Grade grade)
        {
            if (await _context.Grade.FirstOrDefaultAsync(p => p.GradeName == grade.GradeName) == null)
            {
                await _context.Grade.AddAsync(grade);
                await _context.SaveChangesAsync();
                return Ok("grade added");
            }
            else return BadRequest("already have or error");
        }


        //this method is uses to update the grade
        [HttpPut("updategrade")]
        public async Task<IActionResult> UpdateGradeDetailsAsync([FromBody]Grade grade)
        {
            try
            {
                Grade? newgrade = await _context.Grade.FirstOrDefaultAsync(G => G.GradeId.Equals(grade.GradeId));
                if (grade.GradeName != "")
                {
                    newgrade.GradeName = grade.GradeName;
                    _context.Grade.Update(newgrade);
                    await _context.SaveChangesAsync();
                    return Ok(true);
                }
                else
                {
                    return BadRequest(false);
                }
                
            }catch{
                return BadRequest(false);

            }
        }
             
    }
}

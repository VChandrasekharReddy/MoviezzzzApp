using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviezzzzApp.config;
using MoviezzzzApp.models.entites;

namespace MoviezzzzApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly AppDbContext _context;
        public RoleController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("addrole")]
        public async Task<IActionResult> StoreRole([FromBody] Role role)
        {
            try
            {
                await _context.Role.AddAsync(role);
                await _context.SaveChangesAsync();
                return Ok("data saved");

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

            [HttpGet("getroles")]
            public async Task<IActionResult> GetAllRoles()
            {
                var roles = await _context.Role.ToListAsync();

                return Ok(roles);
            }



        //this method is used to update the roles in the role table
        [HttpPut("updaterole")]
        public async Task<IActionResult> UpdateRoleAsync([FromBody] Role role)
        {
            if (role == null || role.RoleId == Guid.Empty)
            {
                return BadRequest("Invalid role data.");
            }
            var existingRole = await _context.Role.FindAsync(role.RoleId);
            if (existingRole == null)
            {
                return NotFound("Role not found.");
            }
            existingRole.RoleName = role.RoleName;
            _context.Role.Update(existingRole);
            await _context.SaveChangesAsync();
            return Ok("Role updated successfully.");
        }


        

    }
}

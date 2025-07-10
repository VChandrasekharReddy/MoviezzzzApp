using System.ComponentModel.DataAnnotations;

namespace MoviezzClient.dto
{
    public class RoleDto
    {
        public Guid RoleId { get; set; }
        [Required]
        public string? RoleName { get; set; }
    }
}

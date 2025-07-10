namespace MoviezzClient.dto
{
    public class PersonDto
    {
        public Guid PersonId { get; set; }
        public string? PersonName { get; set; }
        public string? imageUrl { get; set; }
        public string? Biography { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<RoleDto>? Roles { get; set; }
    }
}

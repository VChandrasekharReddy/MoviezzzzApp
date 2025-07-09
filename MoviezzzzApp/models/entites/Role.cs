namespace MoviezzzzApp.models.entites
{
    public class Role
    {
        public Guid RoleId { get; set; }
        public string? RoleName { get; set; }
        public List<Person>? Persons { get; set; }

    }
}

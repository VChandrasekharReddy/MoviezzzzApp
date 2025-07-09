using System.Text.Json.Serialization;

namespace MoviezzzzApp.models.entites
{
    public class Role
    {
        public Guid RoleId { get; set; }
        public string? RoleName { get; set; }
        [JsonIgnore]
        public List<Person>? Persons { get; set; }

    }
}

namespace MoviezzzzApp.models.entites
{
    public class Person
    {
        public Guid PersonId { get; set; }
        public string? PersonName { get; set; }
        public string? imageUrl { get; set; }
        public string? Biography { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Role>? Roles { get; set; }
        public List<MovieDetails>? MovieDetails { get; set; }
    }
}

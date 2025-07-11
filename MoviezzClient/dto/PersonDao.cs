namespace MoviezzClient.dto
{
    public class PersonDao
    {
        public string? personName { get; set; }
        public string? imageUrl { get; set; }
        public string? biography { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public List<String>? roles { get; set; }
    }
}

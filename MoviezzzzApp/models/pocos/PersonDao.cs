namespace MoviezzzzApp.models.pocos
{
    public class PersonDao
    {
        public string? PersonName { get; set; }
        public string? imageUrl { get; set; }
        public string? Biography { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<String> Roles { get; set; }

    }
}

namespace MoviezzzzApp.models.entites
{
    public class Grade
    {
        public Guid GreadeId { get; set; }
        public String? GrageName { get; set; }

        public List<MovieDetails>? MovieDetails { get; set; }

    }
}

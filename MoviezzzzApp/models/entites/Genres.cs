namespace MoviezzzzApp.models.entites
{
    public class Genres
    {
        public Guid GenresId { get; set; }
        public string? GenresName { get; set; }
        public List<MovieDetails>? MovieDetails { get; set; }

    }
}

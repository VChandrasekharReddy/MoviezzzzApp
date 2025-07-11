using System.Text.Json.Serialization;

namespace MoviezzzzApp.models.entites
{
    public class Movie
    {
        public Guid MovieId { get; set; }
        public string? Title { get; set; }
        public string? imageUrl { get; set; }
        

        public MovieDetails? MovieDetails { get; set; }

    }
}

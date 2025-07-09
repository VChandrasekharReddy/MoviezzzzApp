using System.Text.Json.Serialization;

namespace MoviezzzzApp.models.entites
{
    public class Genres
    {
        public Guid GenresId { get; set; }
        public string? GenresName { get; set; }
        [JsonIgnore]
        public List<MovieDetails>? MovieDetails { get; set; }

    }
}

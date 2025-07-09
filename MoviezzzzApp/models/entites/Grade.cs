using System.Text.Json.Serialization;

namespace MoviezzzzApp.models.entites
{
    public class Grade
    {
        public Guid GradeId { get; set; }
        public String? GrageName { get; set; }
        [JsonIgnore]
        public List<MovieDetails>? MovieDetails { get; set; }

    }
}

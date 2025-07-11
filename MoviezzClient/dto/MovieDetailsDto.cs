using System.Text.Json.Serialization;

namespace MoviezzClient.dto
{
    public class MovieDetailsDto
    {
        public Guid MovieId { get; set; } // PK and FK

        public string? Description { get; set; }

        public int Duration { get; set; }

        public string? Language { get; set; }

        public string? Country { get; set; }

        public float Rating { get; set; }

        public DateTime ReleaseDate { get; set; }
        [JsonIgnore]
        public MovieinfoDto? Movie { get; set; }

        public List<PersonDto>? Cast { get; set; }
        public List<GenresDto>? Genres { get; set; }
        public Guid GradeId { get; set; }//foreign for the gread table
        public GradeDto? Grade { get; set; }
    }
}

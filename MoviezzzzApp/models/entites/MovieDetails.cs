using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviezzzzApp.models.entites
{
    public class MovieDetails
    {
        [Key, ForeignKey("Movie")]
        public Guid MovieId { get; set; } // PK and FK

        public string? Description { get; set; }

        public int Duration { get; set; }

        public string? Language { get; set; }

        public string? Country { get; set; }

        public float Rating { get; set; }

        public DateTime ReleaseDate { get; set; }
        
        public Movie? Movie { get; set; }

        public List<Person>? Cast { get; set; }
        public List<Genres>? Genres { get; set; }
        public Grade? Grade { get; set; }


    }
}

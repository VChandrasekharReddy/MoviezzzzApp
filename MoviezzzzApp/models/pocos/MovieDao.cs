using MoviezzzzApp.models.entites;

namespace MoviezzzzApp.models.pocos
{
    public class MovieDao
    {

        public string? Title { get; set; }
        public string? imageUrl { get; set; }
        public string? Description { get; set; }

        public int Duration { get; set; }

        public string? Language { get; set; }

        public string? Country { get; set; }

        public float Rating { get; set; }

        public DateTime ReleaseDate { get; set; }
        public List<string> cast { get; set; }
        public  List<string> genrs { get; set; }
        public string grade { get; set; }
    }
}

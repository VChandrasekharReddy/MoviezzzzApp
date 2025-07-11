using MoviezzClient.dto;
using MoviezzClient.service;

namespace MoviezzClient.Pages
{
    public class MovieDetails
    {
        private readonly MovieService _movieservice;
        public MovieDetails(MovieService movieservice)
        {
            _movieservice = movieservice;
        }

        public MovieDetailsDto? moviedetails { get; set; } = new MovieDetailsDto();
        public MovieinfoDto? mvieinfo { get; set; } = new MovieinfoDto();



        //public async Task OnGet(string id)
        //{
        //    var movie = new MovieinfoDto()
        //    {
        //        MovieId = Guid.Parse(id)
        //    };

        //    moviedetails = await _movieservice.GetMovieDetailsById(movie);

        //}



    }
}

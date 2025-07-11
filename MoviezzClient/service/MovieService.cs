using MoviezzClient.dto;
using System.Text.Json;

namespace MoviezzClient.service
{
    public class MovieService
    {
        private readonly HttpClient _client;
        public MovieService(IHttpClientFactory client)
        {
            _client = client.CreateClient("movieclient");
        }

        //functin to get the movieinfo liek name and the image
        public async Task<List<MovieinfoDto>?> GetMovieinfoAsync()
        {
            var response = await _client.GetAsync("Movie/getmovies");
            if(response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var str = await response.Content.ReadFromJsonAsync<List<MovieinfoDto>>(options);
                return str ?? new List<MovieinfoDto>();
            }
            else
            {
                return new List<MovieinfoDto>();
            }
        }


        //getting the data from the api based on the movie id 
        public async Task<MovieDetailsDto> GetMovieDetailsById(MovieinfoDto movieinfo)
        {
            Console.WriteLine(movieinfo.MovieId);

            var result = await _client.PostAsJsonAsync("Movie/moviedetails", movieinfo);

            if (result.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var moviedetails = await result.Content.ReadFromJsonAsync<MovieDetailsDto>(options);
                return moviedetails ?? new MovieDetailsDto();
            }

            return new MovieDetailsDto();
        }


        //this method is used to get the movie info only by using the movie id
        public async Task<MovieinfoDto> GetMovieInfoByIdAsync(MovieinfoDto movieinfo)
        {
            var result = await _client.PostAsJsonAsync("Movie/movieinfo", movieinfo);

            if (result.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var movieDetails = await result.Content.ReadFromJsonAsync<MovieinfoDto>(options);
                return movieDetails ?? new MovieinfoDto();
            }

            return new MovieinfoDto();
        }



    }
}

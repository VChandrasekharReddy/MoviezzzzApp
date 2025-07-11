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
            var str = new StringContent(
                JsonSerializer.Serialize(movieinfo),
                System.Text.Encoding.UTF8,
                "application/json"
                );
            var result = await _client.PostAsJsonAsync("Movie/moviedetails", str);
            
            if(result.IsSuccessStatusCode)
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



    }
}

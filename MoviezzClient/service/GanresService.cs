using MoviezzClient.dto;
using System.Text.Json;


namespace MoviezzClient.service
{
    public class GanresService
    {
        private readonly HttpClient _httpClient;
        public GanresService(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("movieclient");
        }


        public async Task<List<GenresDto>> GetAllGanersAsync()
        {
            var response = await _httpClient.GetAsync("Genres/getallgenres");
            if(response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var genres = await response.Content.ReadFromJsonAsync<List<GenresDto>>(options);
                return genres ?? new List<GenresDto>();
            }
            else
            {
                return new List<GenresDto>();
            }
        }


        public async Task<bool> CreateGenresAsync(GenresDto genres)
        {
            var jstring = new StringContent(
                    JsonSerializer.Serialize(genres),
                    System.Text.Encoding.UTF8,
                    "application/json"
                );
            HttpResponseMessage response = await _httpClient.PostAsync("Genres/creategenres",jstring);
            return response.IsSuccessStatusCode;

        }
    }
}

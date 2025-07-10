using MoviezzClient.dto;
using System.Text.Json;

namespace MoviezzClient.service
{
    public class PersonService
    {
        private readonly HttpClient _client;
        public PersonService(IHttpClientFactory client)
        {
            _client = client.CreateClient("movieclient");
        }

        public async Task<List<PersonDto>> GetPersonsAsync()
        {
            var response = await _client.GetAsync("Persion/getallpersons");
            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var persons = await response.Content.ReadFromJsonAsync<List<PersonDto>>(options);

                return persons ?? new List<PersonDto>();
            }
            return new List<PersonDto>();
        }
 

    }
}

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


        //method to get teh person derails along with the roles

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




        //for adding to the data base
        public async Task<bool> AddPersonAsync(PersonDao person)
        {

            var content = new StringContent(
                JsonSerializer.Serialize(person),
                System.Text.Encoding.UTF8,
                "application/json"
                );
            var response = await _client.PostAsync("Persion/addperson", content);
            return response.IsSuccessStatusCode;
        }
    }
}

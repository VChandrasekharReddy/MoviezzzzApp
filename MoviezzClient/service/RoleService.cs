using MoviezzClient.dto;
using System.Net.Http;
using System.Text.Json;

namespace MoviezzClient.service
{
    public class RoleService
    {
        private readonly HttpClient _client;
        public RoleService(IHttpClientFactory clientfactory)
        {
            _client = clientfactory.CreateClient("movieclient");
        }

        //Get method
        //Getting the roles form the api
        public async Task<List<RoleDto>?> GetRolesAsync()
        {
            var response = await _client.GetAsync("Role/getroles");
            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var grades = await response.Content.ReadFromJsonAsync<List<RoleDto>>(options);
                return grades ?? new List<RoleDto>(); // Ensure no null is returned
            }
            else
            {
                return new List<RoleDto>();
            }
        }



        //create (Post)
        //function for adding the role in the role table in the backend database
        public async Task<bool> AddRoleAsync(RoleDto role)
        {
            var jsonStr = new StringContent(
                JsonSerializer.Serialize(role),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await _client.PostAsync("Role/addrole", jsonStr);

            if (!response.IsSuccessStatusCode)
            {
                string errorContent = await response.Content.ReadAsStringAsync();
                // Log the error content, for example:
                Console.WriteLine($"API Error: {errorContent}");
                // Or use your logging framework here
            }

            return response.IsSuccessStatusCode;
        }


        //update
        //function for updat the role in the role table in the backend database
        public async Task<bool> UpdateRoleAsync(RoleDto role)
        {
            var jsonStr = new StringContent(
                JsonSerializer.Serialize(role),
                System.Text.Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage response = await _client.PutAsync("Role/updaterole", jsonStr);
            return response.IsSuccessStatusCode;
        }





    }
}

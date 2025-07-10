using moviezzzzClient.dtos;
namespace moviezzzzClient.service
{
    public class RoleService
    {
        private readonly HttpClient _httpClient;
        public RoleService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient("ApiClient");
        }
        public async Task<List<Role>> GetRolesAsync()
        {
            var response = await _httpClient.GetAsync("getroles");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Role>>();
        }
        public async Task<bool> AddRoleAsync(string roleName)
        {
            var response = await _httpClient.PostAsJsonAsync("api/roles", new { Name = roleName });
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteRoleAsync(string roleName)
        {
            var response = await _httpClient.DeleteAsync($"api/roles/{roleName}");
            return response.IsSuccessStatusCode;
        }
    }
}

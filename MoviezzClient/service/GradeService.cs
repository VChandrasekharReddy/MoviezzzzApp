using MoviezzClient.dto;
using System.Text.Json;
namespace MoviezzClient.service
{
    public class GradeService
    {
        private readonly HttpClient _httpClient;
        public GradeService(IHttpClientFactory clientfactory)
        {
            _httpClient = clientfactory.CreateClient("movieclient");
        }

        //for getting the data from the backend
        public async Task<List<GradeDto>> GetAllGradesAsync()
        {
            var response = await _httpClient.GetAsync("Grade/getallgrades");
            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var grades = await response.Content.ReadFromJsonAsync<List<GradeDto>>(options);
                return grades ?? new List<GradeDto>(); // Ensure no null is returned
            }
            else
            {
                return new List<GradeDto>();
            }
        }


        public async Task<bool> AddGradeAsync(GradeDto grade)
        {
            var jsonStr = new StringContent(
                JsonSerializer.Serialize(grade),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await _httpClient.PostAsync("Grade/addgrade", jsonStr);
            return response.IsSuccessStatusCode;
        }



        //to update the grade using the gradeid and the gradename
        public async Task<bool> UpdateGradeAsync(GradeDto grade)
        {
            var str = new StringContent(
                JsonSerializer.Serialize(grade),
                System.Text.Encoding.UTF8,
                "application/json"

                );
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync("Grade/updategrade", str);
            return response.IsSuccessStatusCode;
        }
        

    }
}

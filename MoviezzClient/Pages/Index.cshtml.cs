using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviezzClient.dto;
using MoviezzClient.service;

namespace MoviezzClient.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MovieService _movieService;


        public IndexModel(ILogger<IndexModel> logger, MovieService service)
        {
            _logger = logger;
            _movieService = service;
        }


        public List<MovieinfoDto>? MoviesList { get; set; } = new List<MovieinfoDto>();



        public async Task OnGet()
        {
            MoviesList = await _movieService.GetMovieinfoAsync();


        }
    }
}

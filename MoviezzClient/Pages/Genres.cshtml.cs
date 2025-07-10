using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviezzClient.service;
using MoviezzClient.dto;

namespace MoviezzClient.Pages
{
    public class GanresModel : PageModel
    {
        private readonly GanresService _service;

        public GanresModel(GanresService service)
        {
            _service = service;
        }

        [BindProperty]
        public GenresDto Ganres { get; set; } = new GenresDto();

        // Public property with PascalCase for binding in Razor
        public List<GenresDto> ganres { get; set; } = new List<GenresDto>();

        public async Task OnGetAsync()
        {
            ganres = await _service.GetAllGanersAsync();
        }
        public async Task<IActionResult> OnPostAsync()
        {

            var result = await _service.CreateGenresAsync(Ganres);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Failed to add grade.");
                ganres = await _service.GetAllGanersAsync();
                return Page();
            }
            return RedirectToPage();

            
        }
    }
}

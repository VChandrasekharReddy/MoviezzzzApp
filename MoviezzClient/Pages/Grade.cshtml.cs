using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviezzClient.service;
using MoviezzClient.dto;
using Microsoft.AspNetCore.Mvc;

namespace MoviezzClient.Pages
{
    public class GradeModel : PageModel
    {
        private readonly GradeService _service;

        [BindProperty]
        public GradeDto Grade { get; set; } = new GradeDto(); 
        public GradeModel(GradeService service)
        {
            _service = service;
        }

        public List<GradeDto> gradeDtos { get; set; } = new List<GradeDto>();

        public async Task OnGetAsync()
        {
            gradeDtos = await _service.GetAllGradesAsync();
        }



        public async Task<IActionResult> OnPostAsync()
        {
            // Check if the model state is valid and GradeName is not empty
            if (string.IsNullOrWhiteSpace(Grade.GradeName))
            {
                // Re-fetch the grade list to redisplay the page with validation errors
                gradeDtos = await _service.GetAllGradesAsync();
                return Page();
            }

            // Call the service to add the new grade
            var success = await _service.AddGradeAsync(Grade);

            if (!success)
            {
                ModelState.AddModelError(string.Empty, "Failed to add grade.");
                gradeDtos = await _service.GetAllGradesAsync();
                return Page();
            }

            // Redirect to GET to show updated list and clear the form
            return RedirectToPage();
        }



       public async Task<IActionResult> OnPostUpdateAsync()
        {
          if(ModelState.IsValid && !string.IsNullOrWhiteSpace(Grade.GradeName))
            {
                var success = await _service.UpdateGradeAsync(Grade);
                if (success)
                {

                    return RedirectToPage();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to update grade.");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid grade data.");
            }
            // Re-fetch the grade list to redisplay the page with validation errors
            gradeDtos = await _service.GetAllGradesAsync();
            return Page();
        }

    }
}

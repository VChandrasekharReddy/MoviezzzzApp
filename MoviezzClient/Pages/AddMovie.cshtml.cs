using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviezzClient.dto;
using MoviezzClient.service;
using System.Text.Json;
using System.Threading.Tasks;

namespace MoviezzClient.Pages
{
    public class AddMovieModel : PageModel
    {
        private readonly MovieService _movieservice;
        private readonly GradeService _gradeservice;
        private readonly PersonService _personservice;
        private readonly GanresService _genresservice;

        public AddMovieModel(GradeService gradeservice,PersonService pservice,GanresService gservice, MovieService mservice)
        {
            _gradeservice = gradeservice;
            _personservice = pservice;
            _genresservice = gservice;
            _movieservice = mservice;
        }

        [BindProperty]
        public MovieDao? Movie { get; set; } = new MovieDao();

        public List<GenresDto>? AvailableGenres { get; set; } = new List<GenresDto>();
        public List<GradeDto>? AvailableGrades { get; set; } = new List<GradeDto>();
        public List<SelectListItem> AvailableGradesSelectList { get; set; } = new();
        public List<PersonDto> AvailableCast { get; set; } = new List<PersonDto>();


        public async Task OnGet()
        {

            AvailableGrades = await _gradeservice.GetAllGradesAsync();

            AvailableCast = await _personservice.GetPersonsAsync();

            AvailableGenres = await _genresservice.GetAllGanersAsync();
            // Convert to SelectListItems
            AvailableGradesSelectList = AvailableGrades.Select(g => new SelectListItem
            {
                Text = g.GradeName,
                Value = g.GradeId.ToString()
            }).ToList();
        }




        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                AvailableGrades = await _gradeservice.GetAllGradesAsync();

                AvailableCast = await _personservice.GetPersonsAsync();

                AvailableGenres = await _genresservice.GetAllGanersAsync();
                // Convert to SelectListItems
                AvailableGradesSelectList = AvailableGrades.Select(g => new SelectListItem
                {
                    Text = g.GradeName,
                    Value = g.GradeId.ToString()
                }).ToList();
                return Page();
            }
            var response = await _movieservice.PostMovieDataAsync(Movie);
            if (!response)
            {
                ModelState.AddModelError(string.Empty, "Failed to add grade.");
                AvailableGrades = await _gradeservice.GetAllGradesAsync();

                AvailableCast = await _personservice.GetPersonsAsync();

                AvailableGenres = await _genresservice.GetAllGanersAsync();
                // Convert to SelectListItems
                AvailableGradesSelectList = AvailableGrades.Select(g => new SelectListItem
                {
                    Text = g.GradeName,
                    Value = g.GradeId.ToString()
                }).ToList();
                return Page();

            }
            return RedirectToPage("Index");

            
        }
    }
}

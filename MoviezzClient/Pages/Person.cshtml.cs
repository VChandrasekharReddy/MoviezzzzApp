using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviezzClient.dto;
using MoviezzClient.service;

namespace MoviezzClient.Pages
{
    public class PersonModel:PageModel
    {
        private readonly PersonService _service;
        private readonly RoleService _servicerole;
        public PersonModel(PersonService service, RoleService servicerole)
        {
            _service = service;
            _servicerole = servicerole;
        }

        public List<PersonDto>? persons { get; set; } =new List<PersonDto>();
        public List<RoleDto>? AvailableRoles { get; set; } = new List<RoleDto>();
        [BindProperty]
        public PersonDto PersonDto { get; set; } = new PersonDto();
        public async Task OnGetAsync()
        {
            persons= await _service.GetPersonsAsync();
            AvailableRoles = await _servicerole.GetRolesAsync();

        }
    }
}

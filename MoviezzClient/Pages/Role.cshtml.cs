using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviezzClient.dto;
using MoviezzClient.service;

namespace MoviezzClient.Pages
{
    public class RoleModel:PageModel
    {

        private readonly RoleService _service;
        public RoleModel(RoleService service)
        {
            _service = service;
        }

        public List<RoleDto>? roles { get; set; } = new List<RoleDto>();

        [BindProperty]
        public RoleDto? role { get; set; } = new RoleDto();




        //onget method to get the roles and display
        public async Task OnGetAsync()
        {
            roles = await  _service.GetRolesAsync();
        }


        public async Task<IActionResult> OnPostAsync()
        {

            // Check if the model state is valid and GradeName is not empty
            if (string.IsNullOrWhiteSpace(role.RoleName))
            {
                // Re-fetch the grade list to redisplay the page with validation errors
                roles = await _service.GetRolesAsync();
                return Page();
            }

            // Call the service to add the new grade
            var success = await _service.AddRoleAsync(role);

            if (!success)
            {
                ModelState.AddModelError(string.Empty, "Failed to add grade.");
                roles = await _service.GetRolesAsync();
                return Page();
            }

            // Redirect to GET to show updated list and clear the form
            return RedirectToPage();
        }



        //update method
        //function to update the role in the backend database
        public async Task<IActionResult> OnPostUpdateAsync()
        {
            if (ModelState.IsValid && role != null && !string.IsNullOrWhiteSpace(role.RoleName))
            {
                var result = await _service.UpdateRoleAsync(role);
                if (!result)
                {
                    ModelState.AddModelError(string.Empty, "Failed to update role.");
                    roles = await _service.GetRolesAsync();
                    return Page();
                }
                return RedirectToPage();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid role data.");
                roles = await _service.GetRolesAsync();
                return Page();
            }
        }
    }

}


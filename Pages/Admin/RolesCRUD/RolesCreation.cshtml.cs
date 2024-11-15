using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;

namespace Assignment_BusApplication.Pages.Admin.RolesCRUD
{
    [Authorize(Roles = "Admin")]
    public class RolesCreationModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesCreationModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [BindProperty]
        [Required]
        public string RoleName { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (!await _roleManager.RoleExistsAsync(RoleName))
            {
                await _roleManager.CreateAsync(new IdentityRole(RoleName));
            }

            return RedirectToPage("Roles");
        }
    }
}

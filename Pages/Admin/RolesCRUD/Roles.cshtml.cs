using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment_BusApplication.Pages.Admin.RolesCRUD
{
    [Authorize(Roles ="Admin")]
    public class RolesModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RolesModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager=roleManager;
        }
        [BindProperty]
        public IEnumerable<IdentityRole> roles { get; set; }
        public void OnGet()
        {
            roles = _roleManager.Roles;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assignment_BusApplication;
using Assignment_BusApplication.Models;
using Microsoft.AspNetCore.Authorization;

namespace Assignment_BusApplication.Pages.Admin.BusRoutesCRUD
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly CybBusContext _context;

        public DeleteModel(CybBusContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BusRoute BusRoute { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busroute = await _context.BusRoutes.FirstOrDefaultAsync(m => m.RouteId == id);

            if (busroute == null)
            {
                return NotFound();
            }
            else
            {
                BusRoute = busroute;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busroute = await _context.BusRoutes.FindAsync(id);
            if (busroute != null)
            {
                BusRoute = busroute;
                _context.BusRoutes.Remove(BusRoute);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

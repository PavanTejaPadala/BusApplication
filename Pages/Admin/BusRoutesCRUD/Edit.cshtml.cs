using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment_BusApplication;
using Assignment_BusApplication.Models;
using Microsoft.AspNetCore.Authorization;

namespace Assignment_BusApplication.Pages.Admin.BusRoutesCRUD
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly CybBusContext _context;

        public EditModel(CybBusContext context)
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

            var busroute =  await _context.BusRoutes.FirstOrDefaultAsync(m => m.RouteId == id);
            if (busroute == null)
            {
                return NotFound();
            }
            BusRoute = busroute;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BusRoute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusRouteExists(BusRoute.RouteId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BusRouteExists(int id)
        {
            return _context.BusRoutes.Any(e => e.RouteId == id);
        }
    }
}

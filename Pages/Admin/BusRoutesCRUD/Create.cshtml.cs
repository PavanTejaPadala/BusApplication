using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Assignment_BusApplication;
using Assignment_BusApplication.Models;
using Microsoft.AspNetCore.Authorization;

namespace Assignment_BusApplication.Pages.Admin.BusRoutesCRUD
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly CybBusContext _context;

        public CreateModel(CybBusContext context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public int BusID { get; set; }
        public IActionResult OnGet(int id)
        {
            BusID = id;
            return Page();
        }

        [BindProperty]
        public BusRoute BusRoute { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            _context.BusRoutes.Add(BusRoute);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Admin/BusCRUD/Index");
        }
    }
}

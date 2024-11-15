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

namespace Assignment_BusApplication.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly CybBusContext _context;

        public DetailsModel(CybBusContext context)
        {
            _context = context;
        }

        public Bus Bus { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bus = await _context.Buses.FirstOrDefaultAsync(m => m.BusId == id);
            if (bus == null)
            {
                return NotFound();
            }
            else
            {
                Bus = bus;
            }
            return Page();
        }
    }
}

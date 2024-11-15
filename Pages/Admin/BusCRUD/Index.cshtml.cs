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
    public class IndexModel : PageModel
    {
        private readonly CybBusContext _context;

        public IndexModel(CybBusContext context)
        {
            _context = context;
        }

        public IList<Bus> Bus { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Bus = await _context.Buses.ToListAsync();
        }
    }
}

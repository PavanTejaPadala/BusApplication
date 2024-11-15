using Assignment_BusApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_BusApplication.Pages
{
    [Authorize]
    public class DetailsOfBusModel : PageModel
    {
        private readonly ILogger<DetailsOfBusModel> _logger;
        private readonly CybBusContext _context;

        public DetailsOfBusModel(ILogger<DetailsOfBusModel> logger, CybBusContext context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public IEnumerable<BusRoute> Routes { get; set; }

        [BindProperty]
        public IEnumerable<Booking> BookedSeats { get; set; }

        [BindProperty]
        public int SelectedRouteId { get; set; }

        [BindProperty]
        public string UserDetail { get; set; }



        public void OnGet(int id, string userId)
        {
            Routes = _context.BusRoutes.Where(e => e.BusId == id && e.DepartureTime>=DateTime.Now.Date).ToList();
            UserDetail = userId;
        }

        public IActionResult OnPost(int routeId, string userId)
        {
            SelectedRouteId = routeId;
            UserDetail = userId;
            BookedSeats = _context.Bookings.Where(e => e.RouteId == routeId).ToList();
            Routes = _context.BusRoutes.Where(e => e.BusId == _context.BusRoutes.FirstOrDefault(e => e.RouteId == routeId).BusId && e.DepartureTime >= DateTime.Now.Date).ToList();
            
            return Page();
        }
    }
}

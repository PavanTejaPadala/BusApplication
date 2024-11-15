using Assignment_BusApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Assignment_BusApplication.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly CybBusContext _context;

        public IndexModel(ILogger<IndexModel> logger, CybBusContext context)
        {
            _logger = logger;
            _context = context;
        }
        [BindProperty]
        [Required(ErrorMessage = "Please enter the source.")]
        public string Source { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please enter the destination.")]
        public string Destination { get; set; }



        [BindProperty]
        [Required(ErrorMessage = "Please enter the Date.")]
        public DateTime Date { get; set; }


        [BindProperty]
        public string UserDetail { get; set; }

        public IEnumerable<Bus> Buses { get; set; }
        public string NoBus { get; set; }

        public void OnGet(string userId)
        {
            UserDetail= userId;
        }

        public IActionResult OnPost(string userId)
        {
            UserDetail = userId;
            var currentDate = DateTime.Now.Date;
            var selectedDate = Date.Date;

            
            if (selectedDate == currentDate)
            {
                
                var busRoutes = _context.BusRoutes.Where(e => e.StartLocation == Source && e.EndLocation == Destination
                    && e.DepartureTime.Date == selectedDate
                    && e.DepartureTime.TimeOfDay >= DateTime.Now.TimeOfDay);

                Buses = _context.Buses.Where(bus => busRoutes.Any(route => route.BusId == bus.BusId)).ToList();
            }
            else
            {
                
                var busRoutes = _context.BusRoutes.Where(e => e.StartLocation == Source && e.EndLocation == Destination
                    && e.DepartureTime.Date == selectedDate);

                Buses = _context.Buses.Where(bus => busRoutes.Any(route => route.BusId == bus.BusId)).ToList();
            }

            if (Buses.Any())
            {
                return Page();
            }
            else
            {
                NoBus = "No Buses Found";
            }

            return Page();
        }

        public IActionResult OnPostViewMore(int id, string userId)
        {
            return RedirectToPage("/DetailsOfBus", new { id, userId });
        }
    }
}

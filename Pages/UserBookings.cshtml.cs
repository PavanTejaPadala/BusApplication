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
    public class UserBookingsModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly CybBusContext _context;

        public UserBookingsModel(ILogger<IndexModel> logger, CybBusContext context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public string UserDetail { get; set; }
        [BindProperty]
        public IEnumerable<Booking> userBookings { get; set; }
        [BindProperty]
        public BusRoute route { get; set; }
        public string NoTickets { get; set; }
        public bool showModal { get; set; }

        public void OnGet(string useremail)
        {
            UserDetail = useremail;
            userBookings = _context.Bookings.Where(e => e.UserId == useremail);
            if (!userBookings.Any())
            {
                NoTickets = "No Booked Tickets";
            }
        }

        public IActionResult OnPostViewMore(string useremail, int routeId)
        {
            UserDetail = useremail;
            userBookings = _context.Bookings.Where(e => e.UserId == useremail);
            route = _context.BusRoutes.FirstOrDefault(e => e.RouteId == routeId);
            showModal = true;
            return Page();
        }

        public IActionResult OnPostCancelTicket(string useremail, int bookingId)
        {
            // Handle the ticket cancellation logic here

            UserDetail = useremail;
            Booking cancleTicket = _context.Bookings.FirstOrDefault(e => e.BookingId == bookingId);
            if (_context.BusRoutes.FirstOrDefault(e => e.RouteId == cancleTicket.RouteId && e.DepartureTime >= DateTime.Now) != null)
            {
                _context.Bookings.Remove(cancleTicket);
                _context.SaveChanges();
            }else
            {
                ViewData["Error"] = "Unable to cancel the Ticket";
            }
            
            userBookings = _context.Bookings.Where(e => e.UserId == useremail);
            return Page();
        }
    }
}

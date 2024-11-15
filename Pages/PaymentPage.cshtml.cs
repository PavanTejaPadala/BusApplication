using Assignment_BusApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment_BusApplication.Pages
{
    [Authorize]
    public class PaymentPageModel : PageModel
    {
        private readonly ILogger<PaymentPageModel> _logger;
        private readonly CybBusContext _context;

        public PaymentPageModel(ILogger<PaymentPageModel> logger, CybBusContext context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public List<string> SelectedSeats { get; set; }

        [BindProperty]
        public int RouteId { get; set; }

        [BindProperty]
        public string UserId { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Passenger Name is required")]
        public List<string> PassengerName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Age is required")]
        public List<int> Age { get; set; }

        [BindProperty]
        public decimal Price { get; set; }

        public void OnGet(List<string> selectedSeats, int routeId, string userId, decimal price)
        {
            SelectedSeats = selectedSeats;
            RouteId = routeId;
            UserId = userId;
            Price = price * selectedSeats.Count;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            for (int i = 0; i < SelectedSeats.Count; i++)
            {
                var booking = new Booking
                {
                    UserId = UserId,
                    RouteId = RouteId,
                    SeatsBooked = SelectedSeats[i],
                    BookingDate = DateTime.Now,
                    PassengerName = PassengerName[i],
                    Age = Age[i]
                };

                _context.Bookings.Add(booking);
            }

            _context.SaveChanges();
            return RedirectToPage("PaymentConformationPage",
                new { selectedSeats = SelectedSeats, passengerName = PassengerName, totalPrice = Price,useremail=UserId });
        }
    }
}

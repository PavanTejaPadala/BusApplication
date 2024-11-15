using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Assignment_BusApplication.Pages
{
    [Authorize]
    public class PaymentConformationPageModel : PageModel
    {
        [BindProperty]
        public List<string> SelectedSeats { get; set; }

        [BindProperty]
        public List<string> PassengerName { get; set; }
        [BindProperty]
        public string UserDetail { get; set; }

        [BindProperty]
        public decimal TotalPrice { get; set; }

        public void OnGet(List<string> selectedSeats, List<string> passengerName, decimal totalPrice,string useremail)
        {
            SelectedSeats = selectedSeats;
            PassengerName = passengerName;
            TotalPrice = totalPrice*selectedSeats.Count;
            UserDetail = useremail;
        }
    }
}

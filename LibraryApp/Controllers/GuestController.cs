using Microsoft.AspNetCore.Mvc;
using LibraryApp.Models;
using LibraryApp.Service;
using LibraryApp.ViewModels;

namespace LibraryApp.Controllers
{
    public class GuestController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IReturnService _returnService;
        private readonly IMessageService _messageService;

        public GuestController(IReservationService reservationService, IReturnService returnService, IMessageService messageService)
        {
            _reservationService = reservationService;
            _returnService = returnService;
            _messageService = messageService;
        }

        // Reserve Section

        // GET: /Guest/Reserve
        public IActionResult Reserve()
        {
            return View();
        }

        // GET: /Guest/ReserveSearchResults
        [HttpGet]
        public IActionResult ReserveSearchResults(string query)
        {
            IEnumerable<Inventory> results = _reservationService.SearchInventory(query);
            return View(results);
        }

        // GET: /Guest/ReserveDetails/5
        public IActionResult ReserveDetails(int id)
        {
            Inventory inventoryDetails = _reservationService.GetInventoryById(id);
            ReservationViewModel reservationDetails = new ReservationViewModel
            {
                Inventory = inventoryDetails,
                Reservation = new Reservation()
            };

            return View(reservationDetails);
        }

        // POST: /Guest/Reserve/
        [HttpPost, ActionName("Reserve")]
        public IActionResult ReserveConfirmed(Reservation reservation)
        {
            _reservationService.ReserveItem(reservation);
            return RedirectToAction("ReservationConfirmation");
        }

// GET: /Guest/ReservationConfirmation
        public IActionResult ReservationConfirmation()
        {
            return View();
        }



        // Return Section

        // Speciality with Returns is, we search the reservations table with email. That way we get user's reservations. Then he can select the reservation he wants to return.
        // Return Section

        // GET: /Guest/Return
        public IActionResult Return()
        {
            return View();
        }

        // GET: /Guest/ReturnSearchResults
        [HttpGet]
        public IActionResult ReturnSearchResults(string email)
        {
            IEnumerable<Reservation> reservations = _returnService.SearchReservationsByEmail(email);
            // enumberable with item name using the reservation.item_id
            return View(reservations);
        }

        // GET: /Guest/ReturnDetails/5
        public IActionResult ReturnDetails(int id)
        {
            ReservationViewModel reservationDetails = _reservationService.GetReservationDetails(id);
            
            Return returnDetails = new Return
            {
                Item_Id = reservationDetails.Inventory.Id,
                Guest_Name = reservationDetails.Reservation.Guest_Name,
                Email = reservationDetails.Reservation.Email
            };
            
            ReturnViewModel returnViewModel = new ReturnViewModel
            {
                Inventory = reservationDetails.Inventory,
                Return = returnDetails
            };
            
            if (returnViewModel == null)
            {
                return NotFound();
            }

            return View(returnViewModel);
        }

        // POST: /Guest/Return/
        [HttpPost, ActionName("Return")]
        public IActionResult ReturnConfirmed(Return returnModel)
        {
            _returnService.ProcessReturn(returnModel);
            return RedirectToAction("ReturnConfirmation");
        }

        // GET: /Guest/ReturnConfirmation
        public IActionResult ReturnConfirmation()
        {
            return View();
        }
        
        // GET: /Guest/SendMessage
        public IActionResult SendMessage()
        {
            return View();
        }

        // POST: /Guest/SendMessage
        [HttpPost]
        public IActionResult SendMessage(GuestMessage guestMessage)
        {
            _messageService.SendMessage(guestMessage);
            return RedirectToAction("MessageConfirmation");
        }

        // GET: /Guest/MessageConfirmation
        public IActionResult MessageConfirmation()
        {
            return View();
        }
    }
}

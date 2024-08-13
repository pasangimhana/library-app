using LibraryApp.Data;
using Microsoft.AspNetCore.Mvc;

using LibraryApp.Service;
using LibraryApp.Models;
using LibraryApp.Service;
using LibraryApp.ViewModels;

namespace LibraryApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly AppDbContext _context;
        private readonly IAdminService _adminService;
        private readonly IReservationService _reservationService;

        public AdminController(ILogger<AdminController> logger, AppDbContext context, IAdminService adminService, IReservationService reservationService)
        {
            _logger = logger;
            _context = context;
            _adminService = adminService;
            _reservationService = reservationService;
        }

        // Sign In
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(SignInModel model)
        {
            if (ModelState.IsValid)
            {
                var authenticationResult = _adminService.Authenticate(model);

                if (authenticationResult == "success")
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", authenticationResult); // Adds the specific error message
                }
            }
            return View(model);
        }

        // Edit Inventory Item (GET)
        public IActionResult Edit(int id)
        {
            var inventoryItem = _adminService.GetInventoryById(id);
            if (inventoryItem == null)
            {
                Console.WriteLine("Inventory item not found");
                return NotFound();
            }
            return View(inventoryItem);
        }

        // Edit Inventory Item (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _adminService.UpdateInventory(inventory);
                return RedirectToAction("Index");
            }
            return View(inventory);
        }

        // Delete Inventory Item (GET)
        public IActionResult Delete(int id)
        {
            var inventoryItem = _adminService.GetInventoryById(id);
            if (inventoryItem == null)
            {
                return NotFound();
            }
            return View(inventoryItem);
        }

        // Delete Inventory Item (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _adminService.DeleteInventory(id);
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var inventory = _adminService.GetAllInventory(); // Assuming a service to get the data
            return View(inventory);
        }

        // create a new inventory item
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inventory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _adminService.AddInventory(inventory);
                return RedirectToAction("Index"); // Redirect to the list view or another appropriate view
            }

            return View(inventory);
        }

        // GET: /Admin/Reservations
        public IActionResult Reservations()
        {
            
            IEnumerable<ReservationViewModel> reservations = _reservationService.GetAllReservations();
            return View(reservations);
        }

        // GET: /Admin/ReservationDetails/5
        public IActionResult ReservationDetails(int id)
        {
            var reservationDetails = _reservationService.GetReservationDetails(id);
            if (reservationDetails == null)
            {
                return NotFound();
            }
            return View(reservationDetails);
        }

        // GET: Admin/GuestMessages (Working)
        public IActionResult GuestMessages()
        {
            var guestMessages = _adminService.GetAllGuestMessages();
            return View(guestMessages);
        }
        
        // GET: Admin/Transactions (Working)
        public IActionResult Transactions()
        {
            var transactions = _adminService.GetAllTransactions();
            return View(transactions);
        }
        
        public IActionResult Returns()
        {
            var returns = _adminService.GetAllReturnViewModels();
            return View(returns);
        }
    }
}

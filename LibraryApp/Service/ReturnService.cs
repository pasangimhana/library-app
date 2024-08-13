using LibraryApp.Data;
using LibraryApp.Models;
using LibraryApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Service
{
    public class ReturnService : IReturnService
    {
        private readonly AppDbContext _context;

        public ReturnService(AppDbContext context)
        {
            _context = context;
        }

        // Search reservations by guest's email
        public IEnumerable<Reservation> SearchReservationsByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));
            }

            if (_context.Reservation == null)
            {
                throw new InvalidOperationException("The Reservation table is not available in the context.");
            }

            return _context.Reservation
                .Where(r => r.Email.ToLower() == email.ToLower())
                .ToList();
        }


        // Get details of a specific reservation for returning an item
        public ReturnViewModel GetReturnDetails(int reservationId)
        {
            var reservation = _context.Reservation.Find(reservationId);
            if (reservation == null) return null;

            var inventoryItem = _context.Inventory.Find(reservation.Item_Id);

            return new ReturnViewModel
            {
                Return = new Return
                {
                    Id = reservation.Id,
                    Item_Id = reservation.Item_Id,
                    Guest_Name = reservation.Guest_Name,
                    Email = reservation.Email,
                    Return_Date = DateTime.Now.ToString("yyyy-MM-dd"),
                    ReturnMessage = "Item returned successfully"
                },
                Inventory = inventoryItem
            };
        }

        // Process the return of an item
        public void ProcessReturn(Return returnModel)
        {
            returnModel.Return_Date = DateTime.Now.ToString("yyyy-MM-dd");
            _context.Return.Add(returnModel);
            _context.SaveChanges();

            // Update the status of the item to 'Available'
            var item = _context.Inventory.Find(returnModel.Item_Id);
            if (item != null)
            {
                item.Status = "Available";
                _context.SaveChanges();

                // Add transaction for the return
                var transaction = new Transaction
                {
                    Transaction_Type = "Return",
                    Reference_Date = DateTime.Now.ToString("yyyy-MM-dd"),
                    Item_Id = returnModel.Item_Id,
                    Guest_Name = returnModel.Guest_Name,
                    Email = returnModel.Email
                };
                _context.Transaction.Add(transaction);
                _context.SaveChanges();
                
                // delete reservation
        // Find and delete the reservation
        var reservation = _context.Reservation
                                  .FirstOrDefault(r => r.Item_Id == returnModel.Item_Id && r.Email == returnModel.Email);
        if (reservation != null)
        {
            _context.Reservation.Remove(reservation);
            _context.SaveChanges();
        }
            }
        }

        // Get all returns (optional, based on your requirements)
        public IEnumerable<ReturnViewModel> GetAllReturns()
        {
            var returns = _context.Return.ToList();
            var returnList = new List<ReturnViewModel>();

            foreach (var ret in returns)
            {
                var inventoryItem = _context.Inventory.Find(ret.Item_Id);

                returnList.Add(new ReturnViewModel
                {
                    Return = ret,
                    Inventory = inventoryItem
                });
            }

            return returnList;
        }
    }
}

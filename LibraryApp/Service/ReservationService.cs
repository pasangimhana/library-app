using LibraryApp.Data;
using LibraryApp.Models;
using LibraryApp.ViewModels;
using LibraryApp.Service;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Service
{
    public class ReservationService : IReservationService
    {
        private readonly AppDbContext _context;

        public ReservationService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Inventory> SearchInventory(string searchQuery)
        {
            if (string.IsNullOrEmpty(searchQuery))
            {
                throw new ArgumentException("Search query cannot be null or empty.", nameof(searchQuery));
            }

            if (_context.Inventory == null)
            {
                throw new InvalidOperationException("The Inventory table is not available in the context.");
            }

            // Search for items based on name and author
            var searchTerms = searchQuery.ToLower().Split(' ');
            try
            {
                var results = _context.Inventory.Where(x => x.Name.Contains(searchQuery) || x.Author.Contains(searchQuery));

                return results;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<Inventory>(); // Return an empty list instead of null
            }
        }


        public ReservationViewModel GetReservationDetails(int reservationId)
        {
            var reservation = _context.Reservation.Find(reservationId);
            if (reservation == null) return null;

            var inventoryItem = _context.Inventory.Find(reservation.Item_Id);

            return new ReservationViewModel
            {
                Reservation = reservation,
                Inventory = inventoryItem
            };
        }

        public void ReserveItem(Reservation reservation)
        {
            reservation.Reservation_Date = DateTime.Now.ToString("yyyy-MM-dd");
            _context.Reservation.Add(reservation);
            _context.SaveChanges();

            // Update the status of the item to 'Reserved'
            var item = _context.Inventory.Find(reservation.Item_Id);
            if (item != null)
            {
                
                item.Status = "Reserved";
                _context.SaveChanges();
                
                // Add transaction
                var transaction = new Transaction
                {
                    Transaction_Type = "Issue",
                    Reference_Date = DateTime.Now.ToString("yyyy-MM-dd"),
                    Item_Id = reservation.Item_Id,
                    Guest_Name = reservation.Guest_Name,
                    Email = reservation.Email
                };
                _context.Transaction.Add(transaction);
                _context.SaveChanges();
            }
        }

        public IEnumerable<ReservationViewModel> GetAllReservations()
        {
            var reservations = _context.Reservation.ToList();
            var reservationList = new List<ReservationViewModel>();

            foreach (var reservation in reservations)
            {
                var inventoryItem = _context.Inventory.Find(reservation.Item_Id);

                reservationList.Add(new ReservationViewModel
                {
                    Reservation = reservation,
                    Inventory = inventoryItem
                });
            }

            return reservationList;
        }

        public Inventory GetInventoryById(int itemId)
        {
           var inventory = _context.Inventory.Find(itemId);

           if (inventory == null) return null;

           return inventory;
        }
    }
}
   
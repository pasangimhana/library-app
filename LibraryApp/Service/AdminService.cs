using LibraryApp.Data;
using LibraryApp.Models;
using LibraryApp.ViewModels;

namespace LibraryApp.Service
{
    public class AdminService : IAdminService
    {
        private readonly AppDbContext _context;

        public AdminService(AppDbContext context)
        {
            _context = context;
        }

        public string Authenticate(SignInModel model)
        {
            // success, wrong password, user not found
            var user = _context.User.FirstOrDefault(x => x.Username == model.Username);

            if (user == null)
            {
                return "User not found";
            }

            if (user.Password == model.Password)
            {
                return "success";
            }

            return "wrong password";
        }

        public IEnumerable<Inventory> GetAllInventory()
        {
            return _context.Inventory;
        }

        public Inventory GetInventoryById(int id)
        {
            return _context.Inventory.FirstOrDefault(x => x.Id == id);
        }

        public void AddInventory(Inventory inventory)
        {
            _context.Inventory.Add(inventory);
            _context.SaveChanges();
        }

        public void UpdateInventory(Inventory inventory)
        {
            var existingInventory = GetInventoryById(inventory.Id);
            if (existingInventory != null)
            {
                existingInventory.Name = inventory.Name;
                existingInventory.Type = inventory.Type;
                existingInventory.Status = inventory.Status;
                existingInventory.ISBN = inventory.ISBN;
                existingInventory.Author = inventory.Author;
            }
            _context.SaveChanges();
        }

        public void DeleteInventory(int id)
        {
            var inventoryItem = GetInventoryById(id);
            if (inventoryItem != null)
            {
                _context.Inventory.Remove(inventoryItem);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return _context.Transaction;
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return _context.Reservation;
        }

        public IEnumerable<GuestMessage> GetAllGuestMessages()
        {
            return _context.GuestMessage;
        }

        public IEnumerable<Inventory> SearchInventory(string searchQuery)
        {
            return _context.Inventory.Where(x => x.Name.Contains(searchQuery) || x.Author.Contains(searchQuery));
        }
        
        public IEnumerable<Return> GetAllReturns()
        {
            return _context.Return;
        }
        
        public IEnumerable<ReservationViewModel> GetAllReservationViewModels()
        {
            var reservationViewModels = new List<ReservationViewModel>();
            var reservations = GetAllReservations();
            foreach (var reservation in reservations)
            {
                var reservationViewModel = new ReservationViewModel
                {
                    Reservation = reservation,
                    Inventory = GetInventoryById(reservation.Item_Id)
                };
                reservationViewModels.Add(reservationViewModel);
            }

            return reservationViewModels;
        }
        
        public IEnumerable<ReturnViewModel> GetAllReturnViewModels()
        {
            var returnViewModels = new List<ReturnViewModel>();
            var returns = GetAllReturns();
            foreach (var returnItem in returns)
            {
                var returnViewModel = new ReturnViewModel
                {
                    Return = returnItem,
                    Inventory = GetInventoryById(returnItem.Item_Id)
                };
                returnViewModels.Add(returnViewModel);
            }

            return returnViewModels;
        }
    }
}

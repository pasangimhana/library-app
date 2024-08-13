using LibraryApp.Models;
using LibraryApp.ViewModels;

    namespace LibraryApp.Service
    {
        public interface IReservationService
        {
        IEnumerable<Inventory> SearchInventory(string searchQuery);
        
        IEnumerable<ReservationViewModel> GetAllReservations();
            ReservationViewModel GetReservationDetails(int reservationId);
            void ReserveItem(Reservation reservation);
        Inventory GetInventoryById(int itemId);
        }
    }

using LibraryApp.Models;
using LibraryApp.ViewModels;

namespace LibraryApp.Service
{
    public interface IAdminService
    {
        IEnumerable<Inventory> GetAllInventory();

        IEnumerable<Inventory> SearchInventory(string searchQuery);

        IEnumerable<Transaction> GetAllTransactions();

        IEnumerable<Reservation> GetAllReservations();
        
        IEnumerable<ReservationViewModel> GetAllReservationViewModels();

        IEnumerable<GuestMessage> GetAllGuestMessages();
        
        IEnumerable<Return> GetAllReturns();
        
        IEnumerable<ReturnViewModel> GetAllReturnViewModels();

        Inventory GetInventoryById(int id);
        void AddInventory(Inventory inventory);
        void UpdateInventory(Inventory inventory);
        void DeleteInventory(int id);

        string Authenticate(SignInModel model);


    }
}

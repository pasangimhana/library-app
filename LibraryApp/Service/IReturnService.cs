using LibraryApp.Models;
using LibraryApp.ViewModels;

namespace LibraryApp.Service;

public interface IReturnService
{
    IEnumerable<Reservation> SearchReservationsByEmail(string email);
    public ReturnViewModel GetReturnDetails(int reservationId);
    public void ProcessReturn(Return returnModel);
    public IEnumerable<ReturnViewModel> GetAllReturns();

}
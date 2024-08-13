using LibraryApp.Models;

namespace LibraryApp.Service;

public interface IMessageService
{
    void SendMessage(GuestMessage message);
}
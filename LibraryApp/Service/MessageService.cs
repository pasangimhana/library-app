using LibraryApp.Data;
using LibraryApp.Models;

namespace LibraryApp.Service
{
    public class MessageService : IMessageService
    {
        private readonly AppDbContext _context;

        public MessageService(AppDbContext context)
        {
            _context = context;
        }

        public void SendMessage(GuestMessage message)
        {
            message.Date = DateTime.Now.ToString("yyyy-MM-dd");
            _context.GuestMessage.Add(message);
            _context.SaveChanges();
        }
    }
}

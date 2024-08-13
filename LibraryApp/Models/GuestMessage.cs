using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Models
{
    public class GuestMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Guest_Name { get; set; }
        
        public string Email { get; set; }

        public string Message { get; set; }
        
        public string Date { get; set; }
    }
}

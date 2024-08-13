using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibraryApp.Models
{
// - Id = Primary Key
// - Reservation_Date = Date of the Reservation
// - Item_Id = Foreign Key from Inventory_Master
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Reservation_Date { get; set; }
        
        public int Item_Id { get; set; }

        public string Guest_Name { get; set; }
        
        public string Email { get; set; }
        
        public string ReservationMessage { get; set; }
    }
}

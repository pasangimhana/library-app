using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibraryApp.Models
{
    public class Return
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Return_Date { get; set; }
        
        public int Item_Id { get; set; }
        
        public string Guest_Name { get; set; }
        
        public string Email { get; set; } 

        public string ReturnMessage { get; set; }
    }
}

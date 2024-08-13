

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Models
{
 public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
        
        public string Name { get; set; }
        
        public string Contact { get; set; }

        public bool Active { get; set; }
    }
}

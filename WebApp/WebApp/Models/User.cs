using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class User
    {
        public int Username { get; set; }
        [StringLength(40, MinimumLength = 4)]
        [Required]
        [Key]
        
        public string Password { get; set; }
        [StringLength(40, MinimumLength = 6)]
        [Required]
        
        public string Email { get; set; }
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")]
        [StringLength(40, MinimumLength = 6)]
        [Required]
        
        public int Creditcard { get; set; }
        [Required]
        
        public DateTime RegisterationDate { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class CreditCard
    {
        [Key]
        [Required]
        public string CardNum { get; set; }
        public string CVV { get; set; }
        public string CardHolder { get; set; }
    }
}

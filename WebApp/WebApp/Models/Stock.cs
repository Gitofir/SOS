using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Stock
    {
        [Key]
        [Required]
        public string name { get; set; }

        public double price { get; set; }

        public double change { get; set; }
    }
}
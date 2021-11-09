using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Orders
    {
        [Key]
        [Required]
        public int OrderNumber { get; set; }

        public DateTime Date { get; set; }

        public string UserName { get; set; }

        public string Stock { get; set; }

        public int Amount { get; set; }

        public double PricePerUnit { get; set; }

        public double Total { get; set; }

        public double Change { get; set; }

    }
}

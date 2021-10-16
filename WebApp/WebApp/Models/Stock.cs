using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string name { get; set; }
        public double price { get; set; }

       // [DataType(DataType.Date)]
       // public DateTime ReleaseDate { get; set; }
    }
}

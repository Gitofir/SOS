﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class MarketIndex
    {
        [Key]
        [Required]
        public string Name { get; set; }
        public ICollection<Stock> Stocks { get; set; }
    }
}

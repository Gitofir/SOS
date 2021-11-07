using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Stock
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
    }
}
||||||| 55ccd38
=======
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
>>>>>>> 3a7376ebed44f88d2c5e2b2065e3db626afe674a

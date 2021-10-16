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
        public float price { get; set; }

       // [DataType(DataType.Date)]
       // public DateTime ReleaseDate { get; set; }
    }
}
||||||| c6b3783
=======
﻿using System;
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
>>>>>>> 42477254d5f84719b471b1ae89a29c9235f31e91

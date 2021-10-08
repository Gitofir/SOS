using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class MyDB : DbContext
    {
        public MyDB(DbContextOptions<MyDB> options)
      : base(options)
        { }

        public MyDB()
        {

        }

        public DbSet<User> Users { get; set; }
    }

}

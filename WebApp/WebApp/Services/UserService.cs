using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Services
{
    public class UserService : IUserService
    {
        private readonly WebAppContext _context;

        public UserService(WebAppContext context)
        {
            _context = context;
        }

        public async Task<User> GetUser(string username)
        {
            User user = await _context.User.FirstOrDefaultAsync(u => u.Username == username);
            return user;
        }

        public async Task UpdateUserStocks(string username, string stockName, int numOfStocks)
        {
            User user = await _context.User.FirstOrDefaultAsync(u => u.Username == username);
            //var s = user.StocksList.FirstOrDefault(stockName);
            /*
            if (s == null)
            {
                user.StocksList.Add(stockName);
            }
            //user.StocksList
            //user.Stocks.Append()
            _context.SaveChanges();
            */
        }
    }
}

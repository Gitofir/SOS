using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Services
{
    public class StockService : IStockService
    {
        private readonly WebAppContext _context;

        public StockService(WebAppContext context)
        {
            _context = context;
        }

        public async Task AddStock(Stock newStock)
        {
            _context.Stock.Add(newStock);
            await _context.SaveChangesAsync();
        }

        //public async Task<IActionResult> Details(string id)

        public async Task<Stock> GetStock(string sName)
        {
            Stock stock = await _context.Stock.FirstOrDefaultAsync(s => s.name == sName);
            return stock;
        }

        public async Task UpdateStockDetails(string sName, double sPrice, double sChange)
        {
            Stock stock = await _context.Stock.FirstOrDefaultAsync(s => s.name == sName);
            stock.price = sPrice;
            stock.change = sChange;
            await _context.SaveChangesAsync();
        }
    }
}

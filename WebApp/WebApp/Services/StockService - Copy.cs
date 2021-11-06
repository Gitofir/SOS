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
        private readonly WebAppContext context;

        public StockService(WebAppContext context)
        {
            this.context = context;
        }

        //public async Task<IActionResult> Details(string id)

        public async Task<Stock> GetStock(string name)
        {
            Stock stock = await this.context.Stock.FirstOrDefaultAsync(s => s.name == name);
            return stock;
        }
    }
}

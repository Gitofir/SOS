using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class TradeController : Controller
    {
        private readonly WebAppContext _context;
        private readonly IStockService _stockService;
        private readonly IUserService _userService;


        public TradeController(WebAppContext context, IStockService stockService, IUserService userService)
        {
            _context = context;
            _stockService = stockService;
            _userService = userService;
        }

        // GET: Trade
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stock.ToListAsync());
        }

        public async Task<IActionResult> Buy(string stockSymbol, int numOfStocks, double price)
        {
            var username = User.FindFirst("username").Value;
            User user = await _userService.GetUser(username);
            await _userService.UpdateUserStocks(username, stockSymbol, numOfStocks, price);
            return View("Index");
        }


        // GET: Trade/Details/5
        public async Task<IActionResult> Details(string symbol)
        {
            if (symbol == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock
                .FirstOrDefaultAsync(m => m.Symbol == symbol);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        // GET: Trade/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trade/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Symbol,Name,Price,Change,Category")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stock);
        }

        // GET: Trade/Edit/5
        public async Task<IActionResult> Edit(string symbol)
        {
            if (symbol == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock.FindAsync(symbol);
            if (stock == null)
            {
                return NotFound();
            }
            return View(stock);
        }

        // POST: Trade/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string symbol, [Bind("Symbol,Name,Price,Change,Category")] Stock stock)
        {
            if (symbol != stock.Symbol)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockExists(stock.Symbol))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(stock);
        }

        // GET: Trade/Delete/5
        public async Task<IActionResult> Delete(string symbol)
        {
            if (symbol == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock
                .FirstOrDefaultAsync(m => m.Symbol == symbol);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        // POST: Trade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string symbol)
        {
            var stock = await _context.Stock.FindAsync(symbol);
            _context.Stock.Remove(stock);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockExists(string symbol)
        {
            return _context.Stock.Any(e => e.Symbol == symbol);
        }
    }
}

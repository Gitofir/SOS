using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;
using System.Net;
using System.Text.Json;
using System.Threading;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class StocksController : Controller
    {
        private readonly WebAppContext _context;
        private readonly IStockService _stockService;
        private readonly IUserService _userService;

        public StocksController(WebAppContext context, IStockService stockService, IUserService userService)
        {
            _context = context;
            _stockService = stockService;
            _userService = userService;
        }
    

        // GET: Stocks
        public async Task<IActionResult> Index()
        {
            using (WebClient client = new WebClient())
            {
                var companies = new List<string>()
                    {
                        "IBM",
                        "TSCO.LON",
                        "300135.SHZ",
                        "BA",
                        "BAB"
                    };
                for (int i = 0; i < companies.Count; i++)
                {
                    string QUERY_URL = "https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=" + companies[i] + "&apikey=H4XBAHBR";
                    Uri queryUri = new Uri(QUERY_URL);
                    //List<SecurityData> prices = client.DownloadString(queryUri).FromCsv<List<SecurityData>>();
                    dynamic json_data = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(client.DownloadString(queryUri));
                    dynamic jsi = json_data["Global Quote"];

                    string d = jsi.GetRawText();
                    Dictionary<string, string> dic = JsonSerializer.Deserialize<Dictionary<string, string>>(d);
                    string s_name = dic["01. symbol"];
                    double s_price = Convert.ToDouble(dic["05. price"]);
                    double s_change = Convert.ToDouble(dic["09. change"]);

                    var s = new Stock { name = s_name, price = s_price, change = s_change };
                    var stock = await _stockService.GetStock(s_name);
                    if (stock == null)
                    {
                        await _stockService.AddStock(s);
                    }
                    else
                    {
                        await _stockService.UpdateStockDetails(s_name, s_price, s_change);
                    }
                    //Thread.Sleep(5000);
                }

            }
            return View(await _context.Stock.ToListAsync());
        }

        // GET: Stocks/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock
                .FirstOrDefaultAsync(m => m.name == id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        // GET: Stocks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("name,price,change")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stock);
        }

        // GET: Stocks/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            return View(stock);
        }

        // POST: Stocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("name,price,change")] Stock stock)
        {
            if (id != stock.name)
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
                    if (!StockExists(stock.name))
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

        // GET: Stocks/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock
                .FirstOrDefaultAsync(m => m.name == id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        // POST: Stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var stock = await _context.Stock.FindAsync(id);
            _context.Stock.Remove(stock);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockExists(string id)
        {
            return _context.Stock.Any(e => e.name == id);
        }
    }
}

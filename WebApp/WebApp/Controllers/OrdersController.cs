using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly WebAppContext _context;
        private readonly IStockService _stockService;
        private readonly IUserService _userService;

        public OrdersController(WebAppContext context, IStockService stockService, IUserService userService)
        {
            _context = context;
            _stockService = stockService;
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> SearchJoin()
        {
            return View(await _context.Order.ToListAsync());
        }

        // OFIR TODO Join search
        // GET: Orders
        [HttpPost]
        public async Task<IActionResult> SearchJoin(string username)
        {
            List<Order> orders = _context.Order.ToList();
            List<Stock> stocks = _context.Stock.ToList();
            List<User> users = _context.User.ToList();

            //var employeeRecord = from o in orders
            //                     join s in stocks on e.Department_Id equals d.DepartmentId into table1
            //                     from d in table1.ToList()
            //                     join i in incentives on e.Incentive_Id equals i.IncentiveId into table2
            //                     from i in table2.ToList()
            //                     select new ViewModel
            //                     {
            //                         employee = e,
            //                         department = d,
            //                         incentive = i
            //                     };
            //return Task.FromResult(View(employeeRecord));
            return View(await _context.Order.ToListAsync());
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Order.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,Date,UserName,Symbol,Amount,PricePerUnit,Total")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Buy/5
        public async Task<IActionResult> Buy(string symbol)
        {
            ViewBag.orderDate = DateTime.Now;
            ViewBag.orderUsername = User.FindFirst("username").Value;
            ViewBag.orderStockSymbol = symbol;
            var stock = await _stockService.GetStock(symbol);
            ViewBag.orderPricePerUnit = stock.Price;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Buy(string symbol, [Bind("OrderID,Date,UserName,Symbol,Amount,PricePerUnit,Total")] Order order)
        {
            if (ModelState.IsValid)
            {
                order.Total = order.PricePerUnit * order.Amount;
                _context.Add(order);
                var stock = await _stockService.GetStock(symbol);
                await _userService.AddStockToList(stock, order.UserName);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,Date,UserName,Symbol,Amount,PricePerUnit,Total")] Order order)
        {
            if (id != order.OrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderID))
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
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.OrderID == id);
        }
    }
}

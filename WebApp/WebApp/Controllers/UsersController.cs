using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly WebAppContext _context;

        public UsersController(WebAppContext context)
        {
            _context = context;
        }

        // GET: Users
        // Ofir TODO authorize admins only
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Search()
        {
            return View(await _context.User.ToListAsync());
        }

        [HttpPost]
        public IActionResult Search(string username, string email)
        {
            
            // Get users and search them
            var all_users = from u in _context.User select u;
            var found_users = new List<User>();

            // Username or Email
            if (!String.IsNullOrEmpty(username))
            {
                // Remove trailing \t
                username = username.Replace("\t", String.Empty);
                var matched_users = all_users.Where(u => (u.Username.Contains(username)));
                var matched_users_list = new List<User>(matched_users);

                found_users = found_users.Concat(matched_users_list).ToList();
            }

            if (!String.IsNullOrEmpty(email))
            {
                // Remove trailing \t
                email = email.Replace("\t", String.Empty);
                var matched_users = all_users.Where(u => (u.Email.Contains(email)));
                var matched_users_list = new List<User>(matched_users);

                found_users = found_users.Concat(matched_users_list).ToList();
            }

            // Return found users
            return View(found_users);
        }

        // GET: Users/Details/5
        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Username == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Register
        public IActionResult Register()
        {
            return View();
        }

        // GET: Users/Create
        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Username,Password,Email,Creditcard,Birthdate,Admin")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFromRegistration([Bind("Username,Password,Email,Creditcard,Birthdate,Admin")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Admin = false;
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError(string.Empty, "");
            return View("Register");
        }

        // GET: Users/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(string id, [Bind("Username,Password,Email,Creditcard,Birthdate,Admin")] User user)
        {
            if (id != user.Username)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Username))
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
            return View(user);
        }

        // GET: Users/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Username == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        private bool UserExists(string id)
        {
            return _context.User.Any(e => e.Username == id);
        }
    }
}
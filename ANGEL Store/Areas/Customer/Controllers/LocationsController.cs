using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ANGEL_Store.Data;
using ANGEL_Store.Models;
using System.Security.Claims;

namespace ANGEL_Store.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class LocationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customer/Locations
        public async Task<IActionResult> Index()
        {
            var Adreesses = await _context.Locations.Where(i => i.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToListAsync();
            return View(Adreesses);
        }

        // GET: Customer/Locations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var location = await _context.Locations
                .FirstOrDefaultAsync(m => m.AddressId == id);
            if (id == null || location == null || location.UserId != userId)
            {
                return NotFound();
            }
            else
            {
                return View(location);
            }

        }

        // GET: Customer/Locations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Locations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Location location)
        {

            location.UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ModelState.Remove("UserId");

            if (ModelState.IsValid)
            {
                _context.Add(location);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(location);
        }

        // GET: Customer/Locations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var location = await _context.Locations.FindAsync(id);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id == null || location.UserId != userId || location == null)
            {
                return NotFound();
            }
            else
            {
                return View(location);
            }

        }

        // POST: Customer/Locations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AddressId,UserId,Street,City,State,phoneNumber,SecPhoneNumber,Address1,Address2")] Location location)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id != location.AddressId)
            {
                return NotFound();
            }
            location.UserId = userId;
            ModelState.Remove("UserId");

            if (ModelState.IsValid)
            {
                try
                {
                    if(location.UserId == userId)
                    {
                        _context.Update(location);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationExists(location.AddressId))
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
            return View(location);
        }

        // GET: Customer/Locations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var location = await _context.Locations
                .FirstOrDefaultAsync(m => m.AddressId == id);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (id == null || location == null || location.UserId != userId)
            {
                return NotFound();
            }
            else
            {
                return View(location);
            }
        }

        // POST: Customer/Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location != null)
            {
                _context.Locations.Remove(location);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool LocationExists(int id)
        {
            return _context.Locations.Any(e => e.AddressId == id);
        }
    }
}

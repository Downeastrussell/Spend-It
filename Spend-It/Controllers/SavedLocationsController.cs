using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spend_It.Data;
using Spend_It.Models;
using Spend_It.Models.LocationViewModels;

namespace Spend_It.Controllers
{
    public class SavedLocationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SavedLocationsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //GET current signed-in user
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: SavedLocations
        public async Task<IActionResult> Index(int? id)
        {
            var currentUser = await GetCurrentUserAsync();
            var viewModel = new SavedLocationIndexData();
  

            viewModel.SavedLocations = await _context.SavedLocations
                .Include(s => s.Location)
                .Include(s => s.User)
                .Include(s => s.Location.City)
                .Include(s => s.Location.LocationType)
                .Include(i => i.Location.PaymentTypeLocations)
                    .ThenInclude(i => i.PaymentType)
                .Include(i => i.Location.PaymentTypeLocations)
                    .ThenInclude(i => i.Location)
                .Where(l => l.UserId == currentUser.Id)
                .ToListAsync();

            //if (id != null)
            //{
            //    ViewData["LocationId"] = id.Value;
            //     Location location = viewModel.SavedLocations.LocationId.Where(
            //        i => i.LocationId == id.Value).Single();
            //    viewModel.PaymentTypes = location.PaymentTypeLocations.Select(s => s.PaymentType);
            //}

            return View(viewModel);
        }

        // GET: SavedLocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savedLocation = await _context.SavedLocations
                .Include(s => s.Location)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.SavedLocationId == id);
            if (savedLocation == null)
            {
                return NotFound();
            }

            return View(savedLocation);
        }

        // GET: SavedLocations/Create
        public IActionResult Create()
        {
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "Description");
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: SavedLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SavedLocationId,UserId,LocationId")] SavedLocation savedLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(savedLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "Description", savedLocation.LocationId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", savedLocation.UserId);
            return View(savedLocation);
        }

        // GET: SavedLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savedLocation = await _context.SavedLocations.FindAsync(id);
            if (savedLocation == null)
            {
                return NotFound();
            }
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "Description", savedLocation.LocationId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", savedLocation.UserId);
            return View(savedLocation);
        }

        // POST: SavedLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SavedLocationId,UserId,LocationId")] SavedLocation savedLocation)
        {
            if (id != savedLocation.SavedLocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(savedLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SavedLocationExists(savedLocation.SavedLocationId))
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
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "Description", savedLocation.LocationId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", savedLocation.UserId);
            return View(savedLocation);
        }

        // GET: SavedLocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savedLocation = await _context.SavedLocations
                .Include(s => s.Location)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.SavedLocationId == id);
            if (savedLocation == null)
            {
                return NotFound();
            }

            return View(savedLocation);
        }

        // POST: SavedLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var savedLocation = await _context.SavedLocations.FindAsync(id);
            _context.SavedLocations.Remove(savedLocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SavedLocationExists(int id)
        {
            return _context.SavedLocations.Any(e => e.SavedLocationId == id);
        }
    }
}

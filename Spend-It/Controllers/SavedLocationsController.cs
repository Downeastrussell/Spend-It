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
        public async Task<IActionResult> Index(
            //int? id,
              string sortOrder,
            string searchString
            )
        {
            ViewData["CurrentSort"] = sortOrder;
            
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CitySortParm"] = String.IsNullOrEmpty(sortOrder) ? "CityName_desc" : "CityName";
            ViewData["CurrentFilter"] = searchString;

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

            switch (sortOrder)
            {
                case "name_desc":
                    viewModel.SavedLocations = viewModel.SavedLocations.OrderByDescending(s => s.Location.LocationName);
                    break;
                case "CityName":
                    viewModel.SavedLocations = viewModel.SavedLocations.OrderBy(s => s.Location.City.CityName);
                    break;
                case "CityName_desc":
                    viewModel.SavedLocations = viewModel.SavedLocations.OrderByDescending(s => s.Location.City.CityName);
                    break;
                default:
                    viewModel.SavedLocations = viewModel.SavedLocations.OrderBy(s => s.Location.LocationName);
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                viewModel.SavedLocations = viewModel.SavedLocations.Where(s => s.Location.City.CityName.Contains(searchString)
                                       || s.Location.City.CityName.Contains(searchString) || s.Location.Description.Contains(searchString));

            }

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
        public async Task<IActionResult> Create(int? id)
        {
            {
                var currentUser = await GetCurrentUserAsync();

                ViewData["LocationId"] = id;
                ViewData["UserId"] = currentUser.Id;
                
                return View();

            }
           
        }

        // POST: SavedLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,LocationId")] SavedLocation savedLocation, int id)
        {
            ModelState.Remove("User");
            ModelState.Remove("Location");
            ModelState.Remove("LocationId");

            if (ModelState.IsValid)
            {
                var CurrentUser = await GetCurrentUserAsync();
                savedLocation.UserId = CurrentUser.Id;
                savedLocation.LocationId = id;

                _context.Add(savedLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

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
        public async Task<IActionResult> Delete(SavedLocation savedLocation1, int id)
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
            savedLocation1.LocationId = savedLocation.LocationId;
            savedLocation1.SavedLocationId = id;

            return View(savedLocation1);
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

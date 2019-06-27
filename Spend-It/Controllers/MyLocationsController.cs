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

namespace Spend_It.Controllers
{
    public class MyLocationsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public MyLocationsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        //GET current signed-in user
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: MyLocations--Locations the signed in user has created
        public async Task<IActionResult> Index()
        {
            var currentUser = await GetCurrentUserAsync();
            var applicationDbContext = _context.Locations.Include(l => l.City)
                .Include(l => l.LocationType)
                .Include(l => l.User)
                .Where(l => l.UserId == currentUser.Id);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MyLocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Locations
                .Include(l => l.City)
                .Include(l => l.LocationType)
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // GET: MyLocations/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName");
            ViewData["LocationTypeId"] = new SelectList(_context.LocationTypes, "LocationTypeId", "LocationTypeName");
            //ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: MyLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationId,DateCreated,Description,LocationName,StreetAddress,UserId,CityId,LocationTypeId")] Location location)
        {

            ModelState.Remove("User");
            ModelState.Remove("UserId");

            if (ModelState.IsValid)
            {
                var CurrentUser = await GetCurrentUserAsync();
                location.UserId = CurrentUser.Id;
                _context.Add(location);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName", location.CityId);
            ViewData["LocationTypeId"] = new SelectList(_context.LocationTypes, "LocationTypeId", "LocationTypeName", location.LocationTypeId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", location.UserId);
            return View(location);
        }

        // GET: MyLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName", location.CityId);
            ViewData["LocationTypeId"] = new SelectList(_context.LocationTypes, "LocationTypeId", "LocationTypeName", location.LocationTypeId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", location.UserId);
            return View(location);
        }

        // POST: MyLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocationId,DateCreated,Description,LocationName,StreetAddress,UserId,CityId,LocationTypeId")] Location location)
        {
            if (id != location.LocationId)
            {
                return NotFound();
            }

            ModelState.Remove("User");
            ModelState.Remove("UserId");
  

            if (ModelState.IsValid)
            {
                try
                {
                    var CurrentUser = await GetCurrentUserAsync();
                    location.UserId = CurrentUser.Id;
                    _context.Update(location);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                  catch (DbUpdateConcurrencyException)
                {
                    if (!LocationExists(location.LocationId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

        }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName", location.CityId);
            ViewData["LocationTypeId"] = new SelectList(_context.LocationTypes, "LocationTypeId", "LocationTypeName", location.LocationTypeId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", location.UserId);
            return View(location);
        }

        // GET: MyLocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Locations
                .Include(l => l.City)
                .Include(l => l.LocationType)
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // POST: MyLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationExists(int id)
        {
            return _context.Locations.Any(e => e.LocationId == id);
        }
    }
}

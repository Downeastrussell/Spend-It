//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Spend_It.Data;
//using Spend_It.Models;
//using Spend_It.Models.LocationViewModels;

//namespace Spend_It.Controllers
//{
//    public class SavedLocationsController : Controller
//    {
//        private readonly ApplicationDbContext _context;
//        private readonly UserManager<ApplicationUser> _userManager;

//        public SavedLocationsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
//        {
//            _userManager = userManager;
//            _context = context;
//        }

//        //GET current signed-in user
//        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


//        //GET Saved Locations the signed in user has added
//        public async Task<IActionResult> Index(int? id)
//        {
//            var currentUser = await GetCurrentUserAsync();
//            var viewModel = new SavedLocationIndexData();
//            viewModel.SavedLocations = await _context.SavedLocations
//                .Include(i => i.UserId)
//                .Include(i => i.Location.City)
//                .Include(i => i.Location.LocationType)
//                .Include(i => i.Location.LocationTypeId)
//                .Include(i => i.Location.PaymentTypeLocations)
//                  .ThenInclude(i => i.PaymentType)
//                .Include(i => i.Location.PaymentTypeLocations)
//                  .ThenInclude(i => i.Location)
//                .Where(i => i.UserId == currentUser.Id)
//                .ToListAsync();


//            if (id != null)
//            {
//                ViewData["LocationId"] = id.Value;
//                Location location = viewModel.Locations.Where(
//                    i => i.LocationId == id.Value).Single();
//                viewModel.PaymentTypes = location.PaymentTypeLocations.Select(s => s.PaymentType);
//            }

//            return View(viewModel);
//        }

//        // GET: SavedLocations/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var location = await _context.Locations
//                .Include(l => l.City)
//                .Include(l => l.LocationType)
//                .Include(l => l.User)
//                .FirstOrDefaultAsync(m => m.LocationId == id);
//            if (location == null)
//            {
//                return NotFound();
//            }

//            return View(location);
//        }

//        // GET: SavedLocations/Create
//        public IActionResult Create()
//        {
//            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName");
//            ViewData["LocationTypeId"] = new SelectList(_context.LocationTypes, "LocationTypeId", "LocationTypeName");
//            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
//            return View();
//        }

//        // POST: SavedLocations/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("LocationId,DateCreated,Description,LocationName,StreetAddress,UserId,CityId,LocationTypeId")] Location location)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(location);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName", location.CityId);
//            ViewData["LocationTypeId"] = new SelectList(_context.LocationTypes, "LocationTypeId", "LocationTypeName", location.LocationTypeId);
//            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", location.UserId);
//            return View(location);
//        }

//        // GET: SavedLocations/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var location = await _context.Locations.FindAsync(id);
//            if (location == null)
//            {
//                return NotFound();
//            }
//            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName", location.CityId);
//            ViewData["LocationTypeId"] = new SelectList(_context.LocationTypes, "LocationTypeId", "LocationTypeName", location.LocationTypeId);
//            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", location.UserId);
//            return View(location);
//        }

//        // POST: SavedLocations/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("LocationId,DateCreated,Description,LocationName,StreetAddress,UserId,CityId,LocationTypeId")] Location location)
//        {
//            if (id != location.LocationId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(location);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!LocationExists(location.LocationId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName", location.CityId);
//            ViewData["LocationTypeId"] = new SelectList(_context.LocationTypes, "LocationTypeId", "LocationTypeName", location.LocationTypeId);
//            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", location.UserId);
//            return View(location);
//        }

//        // GET: SavedLocations/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var location = await _context.Locations
//                .Include(l => l.City)
//                .Include(l => l.LocationType)
//                .Include(l => l.User)
//                .FirstOrDefaultAsync(m => m.LocationId == id);
//            if (location == null)
//            {
//                return NotFound();
//            }

//            return View(location);
//        }

//        // POST: SavedLocations/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var location = await _context.Locations.FindAsync(id);
//            _context.Locations.Remove(location);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool LocationExists(int id)
//        {
//            return _context.Locations.Any(e => e.LocationId == id);
//        }
//    }
//}

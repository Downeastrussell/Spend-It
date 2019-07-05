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
    public class LocationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public LocationsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        //GET current signed-in user
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


        // GET: All Locations from every user
        public async Task<IActionResult> Index(int? id)
        {

 
            var viewModel = new PaymentTypeLocationData();
            viewModel.Locations = await _context.Locations
                  .Include(i => i.City)
                  .Include(i => i.LocationType)
                  .Include(i => i.PaymentTypeLocations)
                    .ThenInclude(i => i.PaymentType)
                  .Include(i => i.PaymentTypeLocations)
                    .ThenInclude(i => i.Location)
                  .OrderBy(i => i.City)

                  .ToListAsync();

            if (id != null)
            {
                ViewData["LocationId"] = id.Value;
                Location location = viewModel.Locations.Where(
                    i => i.LocationId == id.Value).Single();
                viewModel.PaymentTypes = location.PaymentTypeLocations.Select(s => s.PaymentType);
            }

            return View(viewModel);
        }


        //Add to "Saved Locations" (thanks to Sable Bowen!!!)
        [HttpGet]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> AddToSavedLocation(int id)
        {

            //Gets user, products in cart, and the currently open order
            var currentUser = await GetCurrentUserAsync();

            var location = await _context.Locations.FirstOrDefaultAsync(p => p.LocationId == id);

            IEnumerable<SavedLocation> locations = await _context.SavedLocations.Where(o => o.UserId == currentUser.Id).ToListAsync();

    
                SavedLocation saved = new SavedLocation()
                {
                    LocationId = location.LocationId,
                    UserId = currentUser.Id
                };
                _context.Add(saved);
                await _context.SaveChangesAsync();


         

            return View();
        }



        // GET: Locations/Details/5
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

      
    }
}

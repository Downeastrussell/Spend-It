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
        public async Task<IActionResult> Index(
            int? id,
            string sortOrder,
            string searchString)
            //string currentFilter,
            //int? pageNumber)
        {

            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentFilter"] = searchString;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";           
            ViewData["CitySortParm"] = String.IsNullOrEmpty(sortOrder) ? "CityName_desc" : "CityName";


            var viewModel = new PaymentTypeLocationData();
            viewModel.Locations = await _context.Locations
                  .Include(i => i.City)
                  .Include(i => i.LocationType)
                  .Include(i => i.PaymentTypeLocations)
                    .ThenInclude(i => i.PaymentType)
                  .Include(i => i.PaymentTypeLocations)
                    .ThenInclude(i => i.Location)
                  .OrderBy(i => i.City.CityName)
                  .ToListAsync();

            switch (sortOrder)
            {
                case "name_desc":
                    viewModel.Locations = viewModel.Locations.OrderByDescending(s => s.LocationName).ToList();
                    break;
                case "CityName":
                    viewModel.Locations = viewModel.Locations.OrderBy(s => s.City.CityName).ToList();
                    break;
                case "CityName_desc":
                    viewModel.Locations = viewModel.Locations.OrderByDescending(s => s.City.CityName).ToList();
                    break;
                default:
                    viewModel.Locations = viewModel.Locations.OrderBy(s => s.LocationName).ToList();
                    break;
            }


            if (id != null)
            {
                ViewData["LocationId"] = id.Value;
                Location location = viewModel.Locations.Where(
                    i => i.LocationId == id.Value).Single();
                viewModel.PaymentTypes = location.PaymentTypeLocations.Select(s => s.PaymentType);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                viewModel.Locations = viewModel.Locations.Where(s => s.City.CityName.Contains(searchString)
                                       || s.City.CityName.Contains(searchString) || s.Description.Contains(searchString)).ToList();

            }

            return View(viewModel);

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

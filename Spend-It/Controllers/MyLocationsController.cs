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

        //GET Locations the signed in user has created
        public async Task<IActionResult> Index(int? id)
        {
            var currentUser = await GetCurrentUserAsync();
            var viewModel = new PaymentTypeLocationData();
            viewModel.Locations = await _context.Locations
                  .Include(i => i.City)
                  .Include(i => i.LocationType)
                  .Include(i => i.PaymentTypeLocations)
                    .ThenInclude(i => i.PaymentType)
                  .Include(i => i.PaymentTypeLocations)
                    .ThenInclude(i => i.Location)
                  .Where(l => l.UserId == currentUser.Id)
                  .OrderBy(i => i.LocationName)

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

            var location = new Location();
            location.PaymentTypeLocations = new List<PaymentTypeLocation>();
            PopulateAssignedPaymentTypeData(location);
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName");
            ViewData["LocationTypeId"] = new SelectList(_context.LocationTypes, "LocationTypeId", "LocationTypeName");
            ViewData["PaymentTypeId"] = new SelectList(_context.PaymentType, "Id", "Id");
            return View();
        }

        // POST: MyLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationId,DateCreated,Description,LocationName,StreetAddress,UserId,CityId,LocationTypeId, PaymentTypeLocation")] Location location, string[] selectedPaymentTypes)
        {
            {
                location.PaymentTypeLocations = new List<PaymentTypeLocation>();
                foreach (var paymentType in selectedPaymentTypes)
                {
                    var paymentToAdd = new PaymentTypeLocation { LocationId = location.LocationId, PaymentTypeId = int.Parse(paymentType) };
                    location.PaymentTypeLocations.Add(paymentToAdd);
                }
            }

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
            PopulateAssignedPaymentTypeData(location);
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName", location.CityId);
            ViewData["LocationTypeId"] = new SelectList(_context.LocationTypes, "LocationTypeId", "LocationTypeName", location.LocationTypeId);
            return View(location);
        }

        private void PopulateAssignedPaymentTypeData(Location location)
        {
            var allPaymentTypes = _context.PaymentType;
            var locationPaymentTypes = new HashSet<int>(location.PaymentTypeLocations.Select(c => c.PaymentTypeId));
            var viewModel = new List<AssignedPaymentType>();
            foreach (var payment in allPaymentTypes)
            {
                viewModel.Add(new AssignedPaymentType
                {
                    PaymentTypeId = payment.PaymentTypeId,
                    PaymentTypeTicker = payment.PaymentTypeTicker,
                    PaymentTypeName = payment.PaymentTypeTicker,
                    Assigned = locationPaymentTypes.Contains(payment.PaymentTypeId)
                });
            }
            ViewData["PaymentTypes"] = viewModel;
        }



        // GET: MyLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Locations
                .Include(i => i.PaymentTypeLocations)
                    .ThenInclude(i => i.PaymentType)
                    .FirstOrDefaultAsync(m => m.LocationId == id);
            if (location == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName", location.CityId);
            ViewData["LocationTypeId"] = new SelectList(_context.LocationTypes, "LocationTypeId", "LocationTypeName", location.LocationTypeId);
            PopulateAssignedPaymentTypeData(location);
            return View(location);
        }

        // POST: MyLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocationId,DateCreated,Description,LocationName,StreetAddress,UserId,CityId,LocationTypeId")] Location location, string[] selectedPaymentTypes)
        {
            if (id != location.LocationId)
            {
                return NotFound();
            }

                    var CurrentUser = await GetCurrentUserAsync();
                    location.UserId = CurrentUser.Id;

                    var locationToUpdate = await _context.Locations
                        .Include(i => i.PaymentTypeLocations)
                             .ThenInclude(i => i.PaymentType)
                        .FirstOrDefaultAsync(m => m.LocationId == id);
                    //_context.Update(location);
                    //await _context.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));

            if (await TryUpdateModelAsync<Location>(
                            locationToUpdate,
                            "",
                            //i => i.Description,
                            //i => i.LocationName,
                            //i => i.Address,
                            i => i.City,
                            i => i.LocationType))
            { 
                    UpdatePaymentTypeLocationData(selectedPaymentTypes, locationToUpdate);

                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateException /* ex */)
                    {
                        //Log the error (uncomment ex variable name and write a log.)
                        ModelState.AddModelError("", "Unable to save changes. " +
                            "Try again, and if the problem persists, " +
                            "see your system administrator.");
                    }
                    return RedirectToAction(nameof(Index));
            }
                
                UpdatePaymentTypeLocationData(selectedPaymentTypes, locationToUpdate);
                PopulateAssignedPaymentTypeData(locationToUpdate);
                return View(locationToUpdate);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int? id, string[] selectedPaymentTypes)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var locationToUpdate = await _context.Locations
        //        .Include(i => i.PaymentTypeLocations)
        //            .ThenInclude(i => i.PaymentType)
        //        .FirstOrDefaultAsync(m => m. == id);

        //    if (await TryUpdateModelAsync<Instructor>(
        //        instructorToUpdate,
        //        "",
        //        i => i.FirstMidName, i => i.LastName, i => i.HireDate, i => i.OfficeAssignment))
        //    {
        //        if (String.IsNullOrWhiteSpace(instructorToUpdate.OfficeAssignment?.Location))
        //        {
        //            instructorToUpdate.OfficeAssignment = null;
        //        }
        //        UpdateInstructorCourses(selectedCourses, instructorToUpdate);
        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateException /* ex */)
        //        {
        //            //Log the error (uncomment ex variable name and write a log.)
        //            ModelState.AddModelError("", "Unable to save changes. " +
        //                "Try again, and if the problem persists, " +
        //                "see your system administrator.");
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    UpdateInstructorCourses(selectedCourses, instructorToUpdate);
        //    PopulateAssignedCourseData(instructorToUpdate);
        //    return View(instructorToUpdate);
        //}



        //Special method that updates the join tables when Editing "Accepted PaymentTypes"
        private void UpdatePaymentTypeLocationData(string[] selectedPaymentTypes, Location locationToUpdate)
        {
            if (selectedPaymentTypes == null)
            {
                locationToUpdate.PaymentTypeLocations = new List<PaymentTypeLocation>();
                return;
            }

            var selectedCoursesHS = new HashSet<string>(selectedPaymentTypes);
            var instructorCourses = new HashSet<int>
                (locationToUpdate.PaymentTypeLocations.Select(c => c.PaymentType.PaymentTypeId));
            foreach (var paymentType in _context.PaymentType)
            {
                if (selectedCoursesHS.Contains(paymentType.PaymentTypeId.ToString()))
                {
                    if (!instructorCourses.Contains(paymentType.PaymentTypeId))
                    {
                        locationToUpdate.PaymentTypeLocations.Add(new PaymentTypeLocation { LocationId = locationToUpdate.LocationId, PaymentTypeId = paymentType.PaymentTypeId });
                    }
                }
                else
                {

                    if (instructorCourses.Contains(paymentType.PaymentTypeId))
                    {
                        PaymentTypeLocation paymentTypeToRemove = locationToUpdate.PaymentTypeLocations.FirstOrDefault(i => i.PaymentTypeId == paymentType.PaymentTypeId);
                        _context.Remove(paymentTypeToRemove);
                    }
                }
            }
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

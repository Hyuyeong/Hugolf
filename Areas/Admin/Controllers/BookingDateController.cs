using Hugolf.Data;
using Hugolf.Models;
using Hugolf.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hugolf.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class BookingDateController : Controller
    {
        private readonly ApplictionDbContext _db;

        public BookingDateController(ApplictionDbContext db)
        {
            _db = db;
        }

        // GET: BookingDateController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DateOnly dateFrom, DateOnly dateTo)
        {
            DateOnly startDate = dateFrom;
            DateOnly endDate = dateTo;

            int totalDays = endDate.DayNumber - startDate.DayNumber;
            // Loop to generate 14 days (2 weeks)
            for (int i = 0; i < totalDays + 1; i++)
            {
                DateOnly currentDate = startDate.AddDays(i);

                // Check if the date already exists to avoid duplicates
                if (!_db.BookingDates.Any(b => b.Date == currentDate))
                {
                    var bookingDate = new BookingDate
                    {
                        Date = currentDate,
                        IsAvailable = true, // Set to true initially
                    };

                    _db.BookingDates.Add(bookingDate);
                }
                else
                {
                    return BadRequest("You have already created a slot for this date.");
                }
            }

            _db.SaveChanges();
            var bookingDates = _db.BookingDates.OrderBy(b => b.Date).ToList();

            int totalAvailableSeats = _db
                .BookingTimes.Where(b => b.BookingDateId == 5)
                .Sum(b =>
                    (b.PlayerOne == null ? 1 : 0)
                    + (b.PlayerTwo == null ? 1 : 0)
                    + (b.PlayerThree == null ? 1 : 0)
                    + (b.PlayerFour == null ? 1 : 0)
                );
            ViewData["TotalAvailableSeats"] = totalAvailableSeats;
            return RedirectToAction("Index");
        }
    }
}

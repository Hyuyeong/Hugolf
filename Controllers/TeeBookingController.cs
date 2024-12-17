using Hugolf.Data;
using Hugolf.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hugolf.Controllers
{
    public class TeeBookingController : Controller
    {
        private readonly ApplictionDbContext _db;

        public TeeBookingController(ApplictionDbContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            // Loop to generate 14 days (2 weeks)
            for (int i = 0; i < 14; i++)
            {
                DateOnly currentDate = today.AddDays(i);

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
            }

            _db.SaveChanges();
            var bookingDates = _db.BookingDates.OrderBy(b => b.Date).ToList();
            return View(bookingDates);
        }

        public ActionResult Booking(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            BookingDate? bookingDateFromDb = _db.BookingDates.Find(id);
            if (bookingDateFromDb == null)
            {
                return NotFound();
            }

            // Define time range: 7:00 AM to 3:00 PM
            TimeOnly startTime = new TimeOnly(7, 0); // 7:00 AM
            TimeOnly endTime = new TimeOnly(15, 0); // 3:00 PM
            TimeSpan interval = TimeSpan.FromMinutes(8); // 8-minute interval

            // Generate time slots
            var currentTime = startTime;
            while (currentTime <= endTime)
            {
                // Check if this time slot already exists
                if (!_db.BookingTimes.Any(bt => bt.BookingDateId == id && bt.Time == currentTime))
                {
                    var bookingTime = new BookingTime
                    {
                        BookingDateId = id,
                        Time = currentTime,
                        PlayerOne = null, // No players initially
                        PlayerTwo = null,
                        PlayerThree = null,
                        PlayerFour = null,
                    };

                    _db.BookingTimes.Add(bookingTime);
                }

                // Increment the time by the interval
                currentTime = currentTime.Add(interval);
            }

            // Save to database
            _db.SaveChanges();
            var bookingTimes = _db
                .BookingTimes.Where(bt => bt.BookingDateId == id)
                .OrderBy(b => b.Time)
                .ToList();
            return View(bookingTimes);
        }

        // public IActionResult GenerateTwoWeeksDates()
        // {
        //     // Start from today


        //     return RedirectToAction("Index"); // Redirect to a view showing all booking dates
        // }

        // GET: TeeBookingController

        public ActionResult BookingDetail(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            BookingTime? bookingTimeFromDb = _db.BookingTimes.Find(id);
            if (bookingTimeFromDb == null)
            {
                return NotFound();
            }

            return View(bookingTimeFromDb);
        }
    }
}

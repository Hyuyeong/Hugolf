using Hugolf.Data;
using Hugolf.Models;
using Hugolf.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hugolf.Controllers
{
    [Area("Customer")]
    public class TeeBookingController : Controller
    {
        private readonly ApplictionDbContext _db;
        private readonly IUnitOfWork _unitOfWork;

        public TeeBookingController(ApplictionDbContext db, IUnitOfWork unitOfWork)
        {
            _db = db;
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            // DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            // // Loop to generate 14 days (2 weeks)
            // for (int i = 0; i < 14; i++)
            // {
            //     DateOnly currentDate = today.AddDays(i);

            //     // Check if the date already exists to avoid duplicates
            //     if (!_db.BookingDates.Any(b => b.Date == currentDate))
            //     {
            //         var bookingDate = new BookingDate
            //         {
            //             Date = currentDate,
            //             IsAvailable = true, // Set to true initially
            //         };

            //         _db.BookingDates.Add(bookingDate);
            //     }
            // }

            // _db.SaveChanges();
            var bookingDates = _db.BookingDates.OrderBy(b => b.Date).ToList();

            // int totalAvailableSeats = _db
            //     .BookingTimes.Where(b => b.BookingDateId == 5)
            //     .Sum(b =>
            //         (b.PlayerOne == null ? 1 : 0)
            //         + (b.PlayerTwo == null ? 1 : 0)
            //         + (b.PlayerThree == null ? 1 : 0)
            //         + (b.PlayerFour == null ? 1 : 0)
            //     );
            // ViewData["TotalAvailableSeats"] = totalAvailableSeats;

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

        [HttpPost]
        public async Task<IActionResult> CreateBooking(
            int bookingTimeId,
            int holes,
            string player1,
            string player2,
            string player3,
            string player4
        )
        {
            var userName = User.Identity?.Name;

            if (string.IsNullOrEmpty(userName))
            {
                return Unauthorized();
            }

            // Get the booking time
            var booking = await _db.BookingTimes.FirstOrDefaultAsync(b => b.Id == bookingTimeId);
            if (booking == null)
            {
                return NotFound("Booking not found.");
            }

            // Check if the user has already booked a slot for the same BookingDateId
            bool userAlreadyBooked = await _db.BookingTimes.AnyAsync(b =>
                b.BookingDateId == booking.BookingDateId
                && (
                    (b.PlayerOne != null && b.PlayerOne.Contains(userName))
                    || (b.PlayerTwo != null && b.PlayerTwo.Contains(userName))
                    || (b.PlayerThree != null && b.PlayerThree.Contains(userName))
                    || (b.PlayerFour != null && b.PlayerFour.Contains(userName))
                )
            );

            if (userAlreadyBooked)
            {
                return BadRequest("You have already booked a slot for this date.");
            }

            // Assign the user to the first available slot based on selection
            string playerInfo = $"{userName} [holes: {holes}]";

            if (player1 == "1" && string.IsNullOrEmpty(booking.PlayerOne))
            {
                booking.PlayerOne = playerInfo;
            }
            else if (player2 == "2" && string.IsNullOrEmpty(booking.PlayerTwo))
            {
                booking.PlayerTwo = playerInfo;
            }
            else if (player3 == "3" && string.IsNullOrEmpty(booking.PlayerThree))
            {
                booking.PlayerThree = playerInfo;
            }
            else if (player4 == "4" && string.IsNullOrEmpty(booking.PlayerFour))
            {
                booking.PlayerFour = playerInfo;
            }
            else
            {
                return BadRequest("No available slots.");
            }

            _db.BookingTimes.Update(booking);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}

using BookingHotelCourseWork.Data;
using BookingHotelCourseWork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookingHotelCourseWork.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult EditBooking(int ?id)
        {
            ViewBag.RoomId = new SelectList(_context.rooms.ToList(), "RoomId", "RoomId");
            ViewBag.UserId = new SelectList(_context.users.ToList(), "Id", "UserName");
            Booking booking = _context.bookings.Find(id);
            return View(booking);
        }

        [HttpPost]
        public IActionResult EditBooking(Booking booking)
        {
            ViewBag.RoomId = new SelectList(_context.rooms.ToList(), "RoomId", "RoomId");
            ViewBag.UserId = new SelectList(_context.users.ToList(), "Id", "UserName");
            _context.Entry(booking).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index", "Administrator");
        }

        [HttpGet]
        public IActionResult DeleteBooking(int id)
        {
            Booking booking = _context.bookings.FirstOrDefault(b => b.BookingId == id);
            return View(booking);
        }

        public IActionResult DeleteBookingConf(Booking booking,int id)
        {
            _context.Entry(booking).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index", "Administrator");
        }

    }
}

using BookingHotelCourseWork.Data;
using BookingHotelCourseWork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookingHotelCourseWork.Controllers
{
    public class HotelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HotelController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CreateHotel()
        {
            ViewBag.UserId = new SelectList(_context.users.ToList(), "Id", "Name");
            ViewBag.TypeHotelId = new SelectList(_context.typeHotels.ToList(), "TypeHotelId", "Name");
            ViewBag.RaitingId = new SelectList(_context.raitings.ToList(), "RaitingId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult CreateHotel(Hotel hotel)
        {
            ViewBag.UserId = new SelectList(_context.users.ToList(), "Id", "Name");
            ViewBag.TypeHotelId = new SelectList(_context.typeHotels.ToList(), "TypeHotelsId", "Name");
            ViewBag.RaitingId = new SelectList(_context.raitings.ToList(), "RaitingId", "Name");

            _context.hotels.Add(hotel);
            _context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public IActionResult EditHotel(int id)
        {
            ViewBag.UserId = new SelectList(_context.users.ToList(), "Id", "Name");
            ViewBag.TypeHotelId = new SelectList(_context.typeHotels.ToList(), "TypeHotelId", "Name");
            ViewBag.RaitingId = new SelectList(_context.raitings.ToList(), "RaitingId", "Name");
            Hotel hotel = _context.hotels.Find(id);
            return View(hotel);
        }

        [HttpPost]
        public IActionResult EditHotel(Hotel hotel)
        {
            ViewBag.UserId = new SelectList(_context.users.ToList(), "Id", "Name");
            ViewBag.TypeHotelId = new SelectList(_context.typeHotels.ToList(), "TypeHotelId", "Name");
            ViewBag.RaitingId = new SelectList(_context.raitings.ToList(), "RaitingId", "Name");
            if (!ModelState.IsValid)
            {
                _context.Entry(hotel).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            return View(hotel);
        }

        public IActionResult DeleteHotel(int? id)
        {
            Hotel hotel = _context.hotels.Find(id);
            return View(hotel);
        }

        public IActionResult DeleteHotelConf(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public IActionResult DeteailsHotel(int? id)
        {
            ViewData["Rooms"] = _context.rooms
                .Include(c => c.Class)
                .Include(h => h.Hotel)
                .Where(r => r.HotelId == id)
                .OrderBy(r => r.isStatus == true)
                .ToList();
            return View();
        }
    }
}

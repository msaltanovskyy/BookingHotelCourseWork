using BookingHotelCourseWork.Data;
using BookingHotelCourseWork.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BookingHotelCourseWork.Controllers
{
    public class RoomsController : Controller
    {
        private readonly ApplicationDbContext _context; 

        public RoomsController(ApplicationDbContext context)
        {
            _context = context;

       }

         public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult CreateRooms()
        {
            ViewBag.ClassId = new SelectList(_context.classes.ToList(), "ClassId", "Name");
            ViewBag.HotelId = new SelectList(_context.hotels.ToList(), "HotelId", "Name");
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult CreateRooms(Rooms rooms)
        {
            ViewBag.ClassId = new SelectList(_context.classes.ToList(), "ClassId", "Name");
            ViewBag.HotelId = new SelectList(_context.hotels.ToList(), "HotelId", "Name");
            _context.rooms.Add(rooms);
            _context.SaveChanges();
            return RedirectToAction("Index", "Administrator");
            
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult EditRooms(int id)
        {
            ViewBag.ClassId = new SelectList(_context.classes.ToList(), "ClassId", "Name");
            ViewBag.HotelId = new SelectList(_context.hotels.ToList(), "HotelId", "Name");
            Rooms rooms = _context.rooms.Find(id);
            return View(rooms);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult EditRooms(Rooms rooms)
        {
            ViewBag.ClassId = new SelectList(_context.classes.ToList(), "ClassId", "Name");
            ViewBag.HotelId = new SelectList(_context.hotels.ToList(), "HotelId", "Name");
            if (!ModelState.IsValid)
            {
                _context.Entry(rooms).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index", "Administrator");
            }
            return View(rooms);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult DeleteRooms(int? id)
        {
            Rooms rooms = _context.rooms.Find(id);
            return View(rooms);
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult DeleteRoomsConf(Rooms rooms)
        {
            _context.Entry(rooms).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index", "Administrator");
        }

        [HttpGet]
        [Authorize]
        public IActionResult BookingRooms(int ?id)
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult BookingRooms(int id)
        {
            Booking booking = new Booking();
            booking.RoomId = id;
            booking.UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _context.bookings.Add(booking);
            var rooms = _context.rooms.Find(id);
            rooms.isStatus = true;
            _context.Entry(rooms).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }


}


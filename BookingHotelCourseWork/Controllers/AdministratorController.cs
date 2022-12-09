using BookingHotelCourseWork.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BookingHotelCourseWork.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdministratorController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            ViewData["Hotels"] = _context.hotels
                .Include(t => t.TypeHotel)
                .Include(r => r.Raiting)
                .ToList();
            ViewData["Rooms"] = _context.rooms
                .Include(c => c.Class)
                .ToList();
            ViewData["Booking"] = _context.bookings.Where(h => h.room.Hotel.UserId
                        == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)
                        .Include(u => u.user)
                        .Include(r => r.room)
                        .ToList();
            return View();
        }
    }
}

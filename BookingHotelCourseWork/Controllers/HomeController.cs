using BookingHotelCourseWork.Data;
using BookingHotelCourseWork.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace BookingHotelCourseWork.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            ViewData["Hotels"] = _context.hotels
                .Include(t => t.TypeHotel)
                .Include(r => r.Raiting)
                .ToList();
            ViewData["MyBooking"] = _context.bookings
                .Include(r => r.room)
                .Include(u => u.user)
                .Where(u => u.UserId == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)
                .ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
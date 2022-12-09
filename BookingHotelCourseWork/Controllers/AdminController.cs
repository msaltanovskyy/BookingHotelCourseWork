using BookingHotelCourseWork.Data;
using BookingHotelCourseWork.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingHotelCourseWork.Controllers
{

    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context )
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            ViewData["Users"] = _context.users.ToList();
            ViewData["Hotels"] = _context.hotels
                .Include(r => r.Raiting)
                .Include(t => t.TypeHotel)
                .Include(u => u.User)
                .ToList();
            return View();
        }
    }
}

using Exam.Data;
using Exam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Exam.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var matches = await _context.Matches
                .OrderBy(m => m.Date)
                .ToListAsync();

            return View(matches);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Exam.Data;
using Microsoft.EntityFrameworkCore;

namespace Exam.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var teams = await _context.Teams
                .OrderBy(t => t.Ranking)
                .ToListAsync();

            return View(teams);
        }
    }
}

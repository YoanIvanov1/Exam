using Exam.Data;
using Exam.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exam.Controllers
{
    public class MatchesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public MatchesController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var matches = await _context.Matches.OrderBy(m => m.Date).ToListAsync();
            return View(matches);
        }

        [HttpPost]
        public async Task<IActionResult> PlaceBet(int id, string winner, int amount)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return RedirectToPage("/Account/Login", new { area = "Identity" });

            if (amount <= 0)
            {
                TempData["Error"] = "Invalid bet amount.";
                return RedirectToAction("Index");
            }

            if (user.WalletBalance < amount)
            {
                TempData["Error"] = "You don't have enough tokens!";
                return RedirectToAction("Index");
            }

            user.WalletBalance -= amount;
            await _userManager.UpdateAsync(user);

            var match = await _context.Matches.FindAsync(id);

            if (match == null)
            {
                TempData["Error"] = "Match not found.";
                return RedirectToAction("Index");
            }

            var bet = new Bet
            {
                UserId = user.Id,
                MatchId = match.Id,
                Team = winner,
                Amount = amount,
                PlacedAt = DateTime.UtcNow
            };

            _context.Bets.Add(bet);
            await _context.SaveChangesAsync();

            return RedirectToAction("Profile", "Account");
        }
    }
}

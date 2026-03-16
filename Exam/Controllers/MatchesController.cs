using Exam.Data;
using Exam.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exam.Controllers
{
    public class MatchesController : Controller
    {
        private readonly UserDbContext _context;
        private readonly UserManager<User> _userManager;

        private static List<Match> matches = new List<Match>
        {
            new Match { Id = 1, TeamA = "LR", TeamB = "G2", Date = new DateTime(2024, 7, 15), Location = "Stadium A" },
            new Match { Id = 2, TeamA = "KC", TeamB = "MKOI", Date = new DateTime(2024, 7, 16), Location = "Stadium B" },
            new Match { Id = 3, TeamA = "LR", TeamB = "KC", Date = new DateTime(2024, 7, 17), Location = "Stadium C" },
            new Match { Id = 4, TeamA = "G2", TeamB = "MKOI", Date = new DateTime(2024, 7, 18), Location = "Stadium D" }
        };

        public MatchesController(UserDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
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

            var bet = new Bet
            {
                UserId = user.Id,
                MatchId = id,
                Team = winner,
                Amount = amount,
                PlacedAt = DateTime.UtcNow
            };

            _context.Bets.Add(bet);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Bet placed successfully!";
            return RedirectToAction("Index");
        }
    }
}

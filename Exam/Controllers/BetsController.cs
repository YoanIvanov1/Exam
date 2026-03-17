using Exam.Data;
using Exam.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class BetsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager;

    public BetsController(ApplicationDbContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // GET: Edit bet page
    public async Task<IActionResult> Edit(int id)
    {
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return RedirectToPage("/Account/Login", new { area = "Identity" });
        }

        var bet = await _context.Bets
            .FirstOrDefaultAsync(b => b.Id == id && b.UserId == user.Id);

        if (bet == null)
        {
            return NotFound();
        }

        var match = await _context.Matches
            .FirstOrDefaultAsync(m => m.Id == bet.MatchId);

        if (match == null)
        {
            return NotFound();
        }

        ViewBag.TeamA = match.TeamA;
        ViewBag.TeamB = match.TeamB;

        return View(bet);
    }

    // POST: Edit bet
    [HttpPost]
    public async Task<IActionResult> Edit(Bet bet)
    {
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return RedirectToPage("/Account/Login", new { area = "Identity" });
        }

        var existingBet = await _context.Bets
            .FirstOrDefaultAsync(b => b.Id == bet.Id && b.UserId == user.Id);

        if (existingBet == null)
        {
            return NotFound();
        }

        var match = await _context.Matches
            .FirstOrDefaultAsync(m => m.Id == existingBet.MatchId);

        if (match == null)
        {
            return NotFound();
        }

        if (bet.Team != match.TeamA && bet.Team != match.TeamB)
        {
            ViewBag.TeamA = match.TeamA;
            ViewBag.TeamB = match.TeamB;

            return View(bet);
        }

        int oldAmount = existingBet.Amount;
        int newAmount = bet.Amount;

        if (newAmount == 0)
        {
            user.WalletBalance += oldAmount;
            await _userManager.UpdateAsync(user);

            _context.Bets.Remove(existingBet);
            await _context.SaveChangesAsync();

            return RedirectToAction("Profile", "Account");
        }

        if (newAmount < 0)
        {
            ViewBag.TeamA = match.TeamA;
            ViewBag.TeamB = match.TeamB;

            return View(bet);
        }

        int difference = newAmount - oldAmount;

        if (difference > 0)
        {
            if (user.WalletBalance < difference)
            {
                ViewBag.TeamA = match.TeamA;
                ViewBag.TeamB = match.TeamB;

                return View(bet);
            }

            user.WalletBalance -= difference;
        }
        else if (difference < 0)
        {
            user.WalletBalance += Math.Abs(difference);
        }

        await _userManager.UpdateAsync(user);

        existingBet.Team = bet.Team;
        existingBet.Amount = bet.Amount;

        await _context.SaveChangesAsync();

        return RedirectToAction("Profile", "Account");
    }

    // GET: Delete confirmation page
    public async Task<IActionResult> Delete(int id)
    {
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return RedirectToPage("/Account/Login", new { area = "Identity" });
        }

        var bet = await _context.Bets
            .FirstOrDefaultAsync(b => b.Id == id && b.UserId == user.Id);

        if (bet == null)
        {
            return NotFound();
        }

        return View(bet);
    }

    // POST: Delete bet
    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return RedirectToPage("/Account/Login", new { area = "Identity" });
        }

        var bet = await _context.Bets
            .FirstOrDefaultAsync(b => b.Id == id && b.UserId == user.Id);

        if (bet == null)
        {
            return NotFound();
        }

        user.WalletBalance += bet.Amount;
        await _userManager.UpdateAsync(user);

        _context.Bets.Remove(bet);
        await _context.SaveChangesAsync();

        return RedirectToAction("Profile", "Account");
    }
}

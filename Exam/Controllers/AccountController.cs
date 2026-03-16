using Exam.Data;
using Exam.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class AccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly ApplicationDbContext _context;
    private readonly SignInManager<User> _signInManager;

    public AccountController(
        UserManager<User> userManager,
        ApplicationDbContext context,
        SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _context = context;
        _signInManager = signInManager;
    }

    public async Task<IActionResult> Profile()
    {
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
            return RedirectToPage("/Account/Login", new { area = "Identity" });

        var bets = await _context.Bets
            .Where(b => b.UserId == user.Id)
            .OrderByDescending(b => b.PlacedAt)
            .ToListAsync();

        var model = new ProfileViewModel
        {
            Email = user.Email,
            WalletBalance = user.WalletBalance,
            Bets = bets
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}

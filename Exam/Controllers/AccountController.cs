using Exam.Models;
using Exam.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(
            IAccountService accountService,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _accountService = accountService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Profile page
        public async Task<IActionResult> Profile()
        {
            var model = await _accountService.GetProfileAsync(_userManager.GetUserId(User)!);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

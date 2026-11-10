using Exam.Models;
using Exam.Services.Contracts;
using Exam.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
    [Authorize]
    public class BetsController : Controller
    {
        private readonly IBetService _betService;
        private readonly UserManager<User> _userManager;

        public BetsController(IBetService betService, UserManager<User> userManager)
        {
            _betService = betService;
            _userManager = userManager;
        }

        private string CurrentUserId => _userManager.GetUserId(User)!;

        // GET: All bets of the current user
        public async Task<IActionResult> Index()
        {
            var bets = await _betService.GetUserBetsAsync(CurrentUserId);

            return View(bets);
        }

        // GET: Place bet page
        public async Task<IActionResult> Create(int matchId)
        {
            var model = await _betService.GetCreateFormAsync(matchId);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: Place bet
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BetFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var error = await _betService.CreateAsync(model, CurrentUserId);

            if (error != null)
            {
                ModelState.AddModelError(string.Empty, error);
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Edit bet page
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _betService.GetEditFormAsync(id, CurrentUserId);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: Edit bet
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BetFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var error = await _betService.EditAsync(model, CurrentUserId);

            if (error != null)
            {
                ModelState.AddModelError(string.Empty, error);
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Delete confirmation page
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _betService.GetUserBetAsync(id, CurrentUserId);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: Delete bet
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleted = await _betService.DeleteAsync(id, CurrentUserId);

            if (!deleted)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

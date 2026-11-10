using Exam.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
    public class MatchesController : Controller
    {
        private readonly IMatchService _matchService;

        public MatchesController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        // GET: All matches
        public async Task<IActionResult> Index()
        {
            var matches = await _matchService.GetAllAsync();

            return View(matches);
        }
    }
}

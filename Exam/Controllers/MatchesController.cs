using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
    public class MatchesController : Controller
    {
        public IActionResult Index()
        {
            var matches = new List<Models.Match>
            {
                new Models.Match { Id = 1, TeamA = "LR", TeamB = "G2", Date = new DateTime(2024, 7, 15), Location = "Stadium A" },
                new Models.Match { Id = 2, TeamA = "KC", TeamB = "MKOI", Date = new DateTime(2024, 7, 16), Location = "Stadium B" },
                new Models.Match { Id = 3, TeamA = "LR", TeamB = "KC", Date = new DateTime(2024, 7, 17), Location = "Stadium C" },
                new Models.Match { Id = 4, TeamA = "G2", TeamB = "MKOI", Date = new DateTime(2024, 7, 18), Location = "Stadium D" }
            };

            return View(matches);
        }
    }
}

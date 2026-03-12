using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
    public class TeamsController : Controller
    {
        public IActionResult Index()
        {
            var teams = new List<Models.Team>
            {
                new Models.Team { Id = 1, Name = "LR", Region = "Europe", Ranking = 1 },
                new Models.Team { Id = 2, Name = "G2", Region = "Europe", Ranking = 2 },
                new Models.Team { Id = 3, Name = "KC", Region = "Europe", Ranking = 3 },
                new Models.Team { Id = 4, Name = "MKOI", Region = "Europe", Ranking = 4 }
            };

            return View(teams);
        }
    }
}

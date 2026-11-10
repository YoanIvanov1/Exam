using Exam.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public async Task<IActionResult> Index()
        {
            var teams = await _teamService.GetAllAsync();

            return View(teams);
        }
    }
}

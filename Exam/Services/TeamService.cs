using Exam.Data;
using Exam.Services.Contracts;
using Exam.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Exam.Services
{
    public class TeamService : ITeamService
    {
        private readonly ApplicationDbContext _context;

        public TeamService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TeamViewModel>> GetAllAsync()
        {
            return await _context.Teams
                .AsNoTracking()
                .OrderBy(t => t.Ranking)
                .Select(t => new TeamViewModel
                {
                    Name = t.Name,
                    Region = t.Region,
                    Ranking = t.Ranking
                })
                .ToListAsync();
        }
    }
}

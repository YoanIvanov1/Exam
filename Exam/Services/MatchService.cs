using Exam.Data;
using Exam.Services.Contracts;
using Exam.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Exam.Services
{
    public class MatchService : IMatchService
    {
        private readonly ApplicationDbContext _context;

        public MatchService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MatchViewModel>> GetAllAsync()
        {
            return await _context.Matches
                .AsNoTracking()
                .OrderBy(m => m.Date)
                .Select(m => new MatchViewModel
                {
                    Id = m.Id,
                    TeamA = m.TeamA,
                    TeamB = m.TeamB,
                    Date = m.Date,
                    Location = m.Location
                })
                .ToListAsync();
        }
    }
}

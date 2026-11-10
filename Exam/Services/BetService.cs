using Exam.Data;
using Exam.Models;
using Exam.Services.Contracts;
using Exam.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Exam.Services
{
    public class BetService : IBetService
    {
        private readonly ApplicationDbContext _context;

        public BetService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BetViewModel>> GetUserBetsAsync(string userId)
        {
            return await _context.Bets
                .AsNoTracking()
                .Where(b => b.UserId == userId)
                .OrderByDescending(b => b.PlacedAt)
                .Select(b => new BetViewModel
                {
                    Id = b.Id,
                    MatchTitle = b.Match.TeamA + " vs " + b.Match.TeamB,
                    MatchDate = b.Match.Date,
                    Team = b.Team,
                    Amount = b.Amount,
                    PlacedAt = b.PlacedAt
                })
                .ToListAsync();
        }

        public async Task<BetViewModel?> GetUserBetAsync(int id, string userId)
        {
            return await _context.Bets
                .AsNoTracking()
                .Where(b => b.Id == id && b.UserId == userId)
                .Select(b => new BetViewModel
                {
                    Id = b.Id,
                    MatchTitle = b.Match.TeamA + " vs " + b.Match.TeamB,
                    MatchDate = b.Match.Date,
                    Team = b.Team,
                    Amount = b.Amount,
                    PlacedAt = b.PlacedAt
                })
                .FirstOrDefaultAsync();
        }

        public async Task<BetFormViewModel?> GetCreateFormAsync(int matchId)
        {
            return await _context.Matches
                .AsNoTracking()
                .Where(m => m.Id == matchId)
                .Select(m => new BetFormViewModel
                {
                    MatchId = m.Id,
                    TeamA = m.TeamA,
                    TeamB = m.TeamB,
                    Team = m.TeamA
                })
                .FirstOrDefaultAsync();
        }

        public async Task<BetFormViewModel?> GetEditFormAsync(int id, string userId)
        {
            return await _context.Bets
                .AsNoTracking()
                .Where(b => b.Id == id && b.UserId == userId)
                .Select(b => new BetFormViewModel
                {
                    Id = b.Id,
                    MatchId = b.MatchId,
                    TeamA = b.Match.TeamA,
                    TeamB = b.Match.TeamB,
                    Team = b.Team,
                    Amount = b.Amount
                })
                .FirstOrDefaultAsync();
        }

        public async Task<string?> CreateAsync(BetFormViewModel model, string userId)
        {
            var match = await _context.Matches.FindAsync(model.MatchId);
            var user = await _context.Users.FindAsync(userId);

            if (match == null || user == null)
            {
                return "The selected match could not be found.";
            }

            if (model.Team != match.TeamA && model.Team != match.TeamB)
            {
                return "Please choose one of the two teams in this match.";
            }

            if (user.WalletBalance < model.Amount)
            {
                return $"You don't have enough tokens. Your balance is {user.WalletBalance}.";
            }

            user.WalletBalance -= model.Amount;

            var bet = new Bet
            {
                UserId = userId,
                MatchId = match.Id,
                Team = model.Team,
                Amount = model.Amount,
                PlacedAt = DateTime.UtcNow
            };

            _context.Bets.Add(bet);
            await _context.SaveChangesAsync();

            return null;
        }

        public async Task<string?> EditAsync(BetFormViewModel model, string userId)
        {
            var bet = await _context.Bets
                .Include(b => b.Match)
                .Include(b => b.User)
                .FirstOrDefaultAsync(b => b.Id == model.Id && b.UserId == userId);

            if (bet == null)
            {
                return "The bet could not be found.";
            }

            if (model.Team != bet.Match.TeamA && model.Team != bet.Match.TeamB)
            {
                return "Please choose one of the two teams in this match.";
            }

            int difference = model.Amount - bet.Amount;

            if (difference > bet.User.WalletBalance)
            {
                return $"You don't have enough tokens. Your balance is {bet.User.WalletBalance}.";
            }

            bet.User.WalletBalance -= difference;
            bet.Team = model.Team;
            bet.Amount = model.Amount;

            await _context.SaveChangesAsync();

            return null;
        }

        public async Task<bool> DeleteAsync(int id, string userId)
        {
            var bet = await _context.Bets
                .Include(b => b.User)
                .FirstOrDefaultAsync(b => b.Id == id && b.UserId == userId);

            if (bet == null)
            {
                return false;
            }

            bet.User.WalletBalance += bet.Amount;

            _context.Bets.Remove(bet);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

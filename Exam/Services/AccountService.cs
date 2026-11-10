using Exam.Data;
using Exam.Services.Contracts;
using Exam.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Exam.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;

        public AccountService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProfileViewModel?> GetProfileAsync(string userId)
        {
            return await _context.Users
                .AsNoTracking()
                .Where(u => u.Id == userId)
                .Select(u => new ProfileViewModel
                {
                    Email = u.Email!,
                    WalletBalance = u.WalletBalance,
                    BetsCount = u.Bets.Count
                })
                .FirstOrDefaultAsync();
        }
    }
}

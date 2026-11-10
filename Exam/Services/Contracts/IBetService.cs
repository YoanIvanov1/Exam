using Exam.ViewModels;

namespace Exam.Services.Contracts
{
    public interface IBetService
    {
        Task<IEnumerable<BetViewModel>> GetUserBetsAsync(string userId);

        Task<BetViewModel?> GetUserBetAsync(int id, string userId);

        Task<BetFormViewModel?> GetCreateFormAsync(int matchId);

        Task<BetFormViewModel?> GetEditFormAsync(int id, string userId);

        // Returns an error message, or null when the bet was saved.
        Task<string?> CreateAsync(BetFormViewModel model, string userId);

        // Returns an error message, or null when the bet was updated.
        Task<string?> EditAsync(BetFormViewModel model, string userId);

        Task<bool> DeleteAsync(int id, string userId);
    }
}

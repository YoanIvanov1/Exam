using Exam.ViewModels;

namespace Exam.Services.Contracts
{
    public interface IAccountService
    {
        Task<ProfileViewModel?> GetProfileAsync(string userId);
    }
}

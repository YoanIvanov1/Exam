using Exam.ViewModels;

namespace Exam.Services.Contracts
{
    public interface IMatchService
    {
        Task<IEnumerable<MatchViewModel>> GetAllAsync();
    }
}

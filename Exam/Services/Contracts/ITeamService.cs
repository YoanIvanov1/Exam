using Exam.ViewModels;

namespace Exam.Services.Contracts
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamViewModel>> GetAllAsync();
    }
}

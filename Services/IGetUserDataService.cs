using TornHelperBe.Modals;

namespace TornHelperBe.Services
{
    public interface IGetUserDataService
    {
        Task<List<TornPlayerStatus>> GetUserDataAsync();

        Task<UserStats> GetUserStats();
    }
}

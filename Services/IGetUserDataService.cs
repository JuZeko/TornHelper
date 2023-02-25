namespace TornHelperBe.Services
{
    public interface IGetUserDataService
    {
        Task<List<TornPlayerStatus>> GetUserDataAsync();
    }
}

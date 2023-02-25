namespace TornHelperBe.Services
{
    public interface IGetUserDataService
    {
        Task<TornPlayerStatus> GetUserDataAsync();
    }
}

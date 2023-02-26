using System.Text.Json;
using TornHelperBe.Modals;

namespace TornHelperBe.Services
{
    public class GetUserDataService : IGetUserDataService
    {
        private readonly List<string> notActivePlayersId = new List<string>() {  "298167", "879148", "251566", "2061354", "1999595", "507739", "534510", "430622" };
        private List<TornPlayerStatus> tornPlayerStatusData = new List<TornPlayerStatus>();
        private Task<UserStats>? userStatsResponse;

        public async Task<List<TornPlayerStatus>> GetUserDataAsync()
        {
            string[] results = await getAllNotActiveUsersAsync();

            deserializePlayerStatus(results);

            return tornPlayerStatusData;
        }

        public async Task<UserStats> GetUserStats()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("https://api.torn.com/user/2883916?selections=bars&key=8QvnTahAkxkrg4Df");
            var content = await response.Content.ReadAsStringAsync();

            UserStats? userStats = JsonSerializer.Deserialize<UserStats>(content);

            return userStats;
        }

        private void deserializePlayerStatus(string[] results)
        {
            foreach (string result in results)
            {
                TornPlayerStatus? tornPlayerStatus = JsonSerializer.Deserialize<TornPlayerStatus>(result);
                if (tornPlayerStatus != null)
                {
                    tornPlayerStatusData.Add(tornPlayerStatus);
                }
            }
        }

        private async Task<string[]> getAllNotActiveUsersAsync()
        {
            List<Task<string>> tasks = new List<Task<string>>();
            foreach (var playersId in notActivePlayersId)
            {
                tasks.Add(GetUrlAsync($"https://api.torn.com/user/{playersId}?selections=basic&key=8QvnTahAkxkrg4Df"));
            }
            return await Task.WhenAll(tasks);
        }

        private static async Task<string> GetUrlAsync(string url)
        {
            using var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
    }
}
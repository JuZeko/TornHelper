using System.Collections.Generic;
using System.Text.Json;

namespace TornHelperBe.Services
{
    public class GetUserDataService : IGetUserDataService
    {

        private readonly List<string> notActivePlayersId = new List<string>() {"2883916", "298167", "879148", "251566", "2061354", "1999595", "507739", "534510", "430622" };
        public async Task<List<TornPlayerStatus>> GetUserDataAsync()
        {
            using var client = new HttpClient();
            List<TornPlayerStatus> tornPlayerStatusData = new List<TornPlayerStatus>();
            List<Task<string>> tasks = new List<Task<string>>();

            foreach (var playersId in notActivePlayersId)
            {
                tasks.Add(GetUrlAsync($"https://api.torn.com/user/{playersId}?selections=basic&key=VISkdWHmVOS680pT"));
            }

            string[] results = await Task.WhenAll(tasks);

            foreach (string result in results)
            {
                TornPlayerStatus? tornPlayerStatus = JsonSerializer.Deserialize<TornPlayerStatus>(result);
                if (tornPlayerStatus != null)
                {
                    tornPlayerStatusData.Add(tornPlayerStatus);
                }
            }

            return tornPlayerStatusData;
        }

        private static async Task<string> GetUrlAsync(string url)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
    }
}
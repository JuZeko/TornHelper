using System.Text.Json;

namespace TornHelperBe.Services
{
    public class GetUserDataService : IGetUserDataService
    {
        public async Task<List<TornPlayerStatus>> GetUserDataAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("https://api.torn.com/user/2883916?selections=basic&key=VISkdWHmVOS680pT");
            List<TornPlayerStatus> tornPlayerStatusData = new List<TornPlayerStatus>();

            List<Task<string>> tasks = new List<Task<string>>();
            tasks.Add(GetUrlAsync("https://api.torn.com/user/298167?selections=basic&key=VISkdWHmVOS680pT"));
            tasks.Add(GetUrlAsync("https://api.torn.com/user/879148?selections=basic&key=VISkdWHmVOS680pT"));
            tasks.Add(GetUrlAsync("https://api.torn.com/user/251566?selections=basic&key=VISkdWHmVOS680pT"));
            tasks.Add(GetUrlAsync("https://api.torn.com/user/2061354?selections=basic&key=VISkdWHmVOS680pT"));
            tasks.Add(GetUrlAsync("https://api.torn.com/user/1999595?selections=basic&key=VISkdWHmVOS680pT"));
            tasks.Add(GetUrlAsync("https://api.torn.com/user/1776074?selections=basic&key=VISkdWHmVOS680pT"));
            tasks.Add(GetUrlAsync("https://api.torn.com/user/507739?selections=basic&key=VISkdWHmVOS680pT"));
            tasks.Add(GetUrlAsync("https://api.torn.com/user/534510?selections=basic&key=VISkdWHmVOS680pT"));
            tasks.Add(GetUrlAsync("https://api.torn.com/user/430622?selections=basic&key=VISkdWHmVOS680pT"));
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
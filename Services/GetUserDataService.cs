using System;
using System.Text.Json;

namespace TornHelperBe.Services
{
    public class GetUserDataService : IGetUserDataService
    {

        public async Task<TornPlayerStatus?> GetUserDataAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("https://api.torn.com/user/2883916?selections=basic&key=VISkdWHmVOS680pT");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                TornPlayerStatus? tornPlayerStatus = JsonSerializer.Deserialize<TornPlayerStatus>(content);
                return tornPlayerStatus;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }
        }
    }
}
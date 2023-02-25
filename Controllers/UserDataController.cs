using Microsoft.AspNetCore.Mvc;
using TornHelperBe.Services;

namespace TornHelperBe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserDataController : ControllerBase
    {
        private readonly IGetUserDataService _getUserData;

        public UserDataController(IGetUserDataService getUserData)
        {
            _getUserData = getUserData;
        }

        [HttpGet]
        public Task<List<TornPlayerStatus?>> Get() => _getUserData.GetUserDataAsync();
    }
}
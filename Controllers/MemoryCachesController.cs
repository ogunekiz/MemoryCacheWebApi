using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MemoryCacheWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemoryCachesController : ControllerBase
    {

        private readonly IMemoryCache _memoryCache;

        public MemoryCachesController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpGet("GetNames")]
        public IActionResult GetNames()
        {
            List<string> names = new();

            names = _memoryCache.Get<List<string>>("names");

            if (names is null)
            {
                names = new()
            {
                "Test1",
                "Test2",
                "Test3",
                "Test4",
                "Test5",
                "Test6",
                "Test7",
                "Test8",
            };

                Thread.Sleep(3000);
                _memoryCache.Set("names", names, TimeSpan.FromSeconds(5));
            }

            return Ok(names);
        }


    }
}

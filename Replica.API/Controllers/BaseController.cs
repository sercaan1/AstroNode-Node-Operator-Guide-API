using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Replica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public readonly IMemoryCache _cache;
        public MemoryCacheEntryOptions memoryCacheOptions;

        public BaseController(IMemoryCache cache)
        {
            _cache = cache;
            memoryCacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                .SetSize(1024);
        }
    }
}

using Business.Abstracts;
using Dtos.SocialMedias;
using Microsoft.AspNetCore.Mvc;

namespace Replica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SocialMediaCreateDto entity)
        {
            if (ModelState.IsValid)
            {
                var addSocialMediaResult = await _socialMediaService.AddAsync(entity);

                if (addSocialMediaResult.IsSuccess)
                    return Ok(addSocialMediaResult.Data);

                return BadRequest(addSocialMediaResult.Message);
            }

            return BadRequest(ModelState);
        }
    }
}

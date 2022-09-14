using Business.Abstracts;
using Dtos.Guides;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Replica.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuideController : ControllerBase
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] GuideCreateDto guideCreateDto)
        {
            if (ModelState.IsValid)
            {
                var addGuideResult = await _guideService.AddAsync(guideCreateDto);

                if (addGuideResult.IsSuccess)
                    return Ok(addGuideResult.Data);

                return BadRequest(addGuideResult.Message);
            }

            return BadRequest(ModelState);
        }
    }
}

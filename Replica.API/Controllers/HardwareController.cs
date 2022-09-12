using Business.Abstracts;
using Dtos.Hardwares;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Replica.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HardwareController : ControllerBase
    {
        private readonly IHardwareService _hardwareService;

        public HardwareController(IHardwareService hardwareService)
        {
            _hardwareService = hardwareService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] HardwareCreateDto entity)
        {
            if (ModelState.IsValid)
            {
                var addHardwareResult = await _hardwareService.AddAsync(entity);

                if (addHardwareResult.IsSuccess)
                    return Ok(addHardwareResult.Data);

                return BadRequest(addHardwareResult.Message);
            }

            return BadRequest(ModelState);
        }
    }
}

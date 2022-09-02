﻿using Business.Abstracts;
using Dtos.Hardwares;
using Microsoft.AspNetCore.Mvc;

namespace Replica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HardwareController : ControllerBase
    {
        private readonly IHardwareService _hardwareService;

        public HardwareController(IHardwareService hardwareService)
        {
            _hardwareService = hardwareService;
        }

        [HttpPost]
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

﻿using Business.Abstracts;
using Dtos.Nodes;
using Microsoft.AspNetCore.Mvc;

namespace Replica.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NodeController : ControllerBase
    {
        private readonly INodeService _nodeService;

        public NodeController(INodeService nodeService)
        {
            _nodeService = nodeService;
        }

        [HttpPost(Name = "CreateNode")]
        public async Task<IActionResult> Create([FromBody] NodeCreateDto nodeCreateDto)
        {
            if (ModelState.IsValid)
            {
                var creationResult = await _nodeService.AddAsync(nodeCreateDto);

                if (creationResult.IsSuccess)
                    return Ok(creationResult.Data);

                return BadRequest(creationResult.Message);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("ActiveNodes")]
        public async Task<IActionResult> GetActiveNodes()
        {
            var getActiveNodesResult = await _nodeService.GetActiveNodesAsync();

            if (getActiveNodesResult.IsSuccess)
            {
                return Ok(getActiveNodesResult.Data);
            }

            return NotFound();
        }

        [HttpGet("DoneNodes")]
        public async Task<IActionResult> GetDoneNodes()
        {
            var getActiveNodesResult = await _nodeService.GetDoneNodesAsync();

            if (getActiveNodesResult.IsSuccess)
            {
                return Ok(getActiveNodesResult.Data);
            }

            return NotFound();
        }

        [HttpGet("AllNodes")]
        public async Task<IActionResult> GetAllNodes()
        {
            var getActiveNodesResult = await _nodeService.GetAllAsync();

            if (getActiveNodesResult.IsSuccess)
            {
                return Ok(getActiveNodesResult.Data);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var getNodeResult = await _nodeService.GetById(id);

            if (getNodeResult.IsSuccess)
                return Ok(getNodeResult.Data);

            return NotFound(getNodeResult.Message);
        }
    }
}

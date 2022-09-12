using Business.Abstracts;
using Dtos.Nodes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Replica.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NodeController : BaseController
    {
        private readonly INodeService _nodeService;

        public NodeController(INodeService nodeService, IMemoryCache memoryCache) : base(memoryCache)
        {
            _nodeService = nodeService;
        }

        [HttpPost]
        [Authorize]
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

        [HttpGet("AllNodes")]
        public async Task<IActionResult> GetAllNodes()
        {
            if (_cache.TryGetValue("nodeListCacheKey", out List<NodeListDto> allNodes))
            {
                return Ok(allNodes);
            }
            else
            {
                var getAllNodesResponse = await _nodeService.GetAllAsync();

                if (getAllNodesResponse.IsSuccess)
                {
                    allNodes = getAllNodesResponse.Data;

                    _cache.Set("nodeListCacheKey", allNodes, memoryCacheOptions);

                    return Ok(allNodes);
                }

                return NotFound(getAllNodesResponse.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var getNodeResult = await _nodeService.GetById(id);

            if (getNodeResult.IsSuccess)
                return Ok(getNodeResult.Data);

            return NotFound(getNodeResult.Message);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteNodeResult = await _nodeService.DeleteAsync(id);

            if (deleteNodeResult)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] NodeUpdateDto nodeUpdateDto)
        {
            var updateNodeResult = await _nodeService.UpdateAsync(nodeUpdateDto);

            if (updateNodeResult.IsSuccess)
            {
                return Ok(updateNodeResult.Data);
            }

            return BadRequest(updateNodeResult.Message);
        }
    }
}

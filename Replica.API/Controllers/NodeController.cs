using Business.Abstracts;
using Dtos.Nodes;
using Microsoft.AspNetCore.Mvc;

namespace Replica.API.Controllers
{
    [ApiController]
    public class NodeController : Controller
    {
        private readonly INodeService _nodeService;

        public NodeController(INodeService nodeService)
        {
            _nodeService = nodeService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NodeCreateDto nodeCreateDto)
        {
            if (ModelState.IsValid)
            {
                var creationResult = await _nodeService.AddAsync(nodeCreateDto);

                if (creationResult.IsSuccess)
                    return Ok(creationResult.Data);

                return BadRequest(creationResult.Data);
            }

            return BadRequest(ModelState);
        }
    }
}

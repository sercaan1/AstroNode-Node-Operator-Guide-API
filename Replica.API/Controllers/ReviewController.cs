using Business.Abstracts;
using Dtos.Reviews;
using Microsoft.AspNetCore.Mvc;

namespace Replica.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReviewCreateDto entity)
        {
            if (ModelState.IsValid)
            {
                var addReviewResult = await _reviewService.AddAsync(entity);

                if (addReviewResult.IsSuccess)
                    return Ok(addReviewResult.Data);

                return BadRequest(addReviewResult.Message);
            }

            return BadRequest(ModelState);
        }
    }
}

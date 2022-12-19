using tutorium.Dtos.ReviewDto;
using tutorium.Services.ReviewService;
using Microsoft.AspNetCore.Mvc;
using tutorium.Utils;
using Microsoft.AspNetCore.Authorization;

namespace tutorium.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(MessageObject), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MessageObject), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<GetReviewDto>> CreateReview(CreateReviewDto createReviewDto)
        {
            return CreatedAtAction(null, await _reviewService.CreateReview(createReviewDto));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(MessageObject), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(MessageObject), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteReview(int id)
        {
            await _reviewService.DeleteReview(id);
            return NoContent();
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(MessageObject), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetReviewDto>> UpdateCourse(int id, UpdateReviewDto updateReviewDto)
        {
            return Ok(await _reviewService.UpdateReview(id, updateReviewDto));
        }
    }
}

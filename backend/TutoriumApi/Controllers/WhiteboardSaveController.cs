using tutorium.Dtos.WhiteboardSaveDto;
using tutorium.Services.WhiteboardSaveService;
using Microsoft.AspNetCore.Mvc;
using tutorium.Utils;
using Microsoft.AspNetCore.Authorization;

namespace tutorium.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WhiteboardSaveController : ControllerBase
    {
        private readonly IWhitebaordSaveService _whiteboardSaveService;
        public WhiteboardSaveController(IWhitebaordSaveService whitebaordSaveService)
        {
            _whiteboardSaveService = whitebaordSaveService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(MessageObject), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(MessageObject), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetWhiteboardSaveDto>> CreateWhiteboardSave([FromForm] CreateWhiteboardSaveDto createWhiteboardSaveDto)
        {
            return CreatedAtAction(null, await _whiteboardSaveService.CreateWhiteboardSave(createWhiteboardSaveDto));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(MessageObject), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(MessageObject), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteWhiteboardSave(int id)
        {
            await _whiteboardSaveService.DeleteWhiteboardSave(id);
            return NoContent();
        }
    }
}

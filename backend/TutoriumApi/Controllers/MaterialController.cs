using tutorium.Dtos.MaterialDto;
using tutorium.Services.MaterialService;
using Microsoft.AspNetCore.Mvc;
using tutorium.Utils;
using Microsoft.AspNetCore.Authorization;

namespace tutorium.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _materialService;
        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(MessageObject), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MessageObject), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(MessageObject), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetMaterialDto>> CreateMaterial([FromForm] CreateMaterialDto createMaterialDto)
        {
            return CreatedAtAction(null, await _materialService.CreateMaterial(createMaterialDto));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(MessageObject), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(MessageObject), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteMaterial(int id)
        {
            await _materialService.DeleteMaterial(id);
            return NoContent();
        }


        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(MessageObject), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetMaterialDto>> UpdateCourse(int id, UpdateMaterialDto updateMaterialDto)
        {
            return Ok(await _materialService.UpdateMaterial(id, updateMaterialDto));
        }
    }
}

using tutorium.Dtos.CourseDto;
using tutorium.Services.CourseService;
using Microsoft.AspNetCore.Mvc;
using tutorium.Utils;
using Microsoft.AspNetCore.Authorization;

namespace tutorium.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(MessageObject), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MessageObject), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<GetCourseDto>> CreateCourse(CreateCourseDto createCourseDto)
        {
            return CreatedAtAction(null, await _courseService.CreateCourse(createCourseDto));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(MessageObject), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(MessageObject), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteCourse(int id)
        {
            await _courseService.DeleteCourse(id);
            return NoContent();
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MessageObject), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetCourseDto>> GetCourse(int id)
        {
            return Ok(await _courseService.GetCourse(id));
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(MessageObject), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetCourseDto>> UpdateCourse(int id, UpdateCourseDto updateCourseDto)
        {
            return Ok(await _courseService.UpdateCourse(id, updateCourseDto));
        }
    }
}

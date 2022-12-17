using tutorium.Dtos.CourseDto;

namespace tutorium.Services.CourseService
{
    public interface ICourseService
    {

        Task<GetCourseDto> CreateCourse(CreateCourseDto createCourseDto);
        Task DeleteCourse(int courseId);
        Task<GetCourseDto> GetCourse(int courseId);
        Task<GetCourseDto> UpdateCourse(int courseId, UpdateCourseDto updateCourseDto);
    }
}

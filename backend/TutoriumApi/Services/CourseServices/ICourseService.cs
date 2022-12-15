using System.Collections.Generic;
using System.Threading.Tasks;
using tutorium.Dtos.CourseDto;
using tutorium.Models;

namespace tutorium.Services.CourseServices
{
    public interface ICourseService
    {

        Task<GetCourseDto> CreateCourse(CreateCourseDto createCourseDto);
        Task DeleteCourse(int courseId);
        Task<GetCourseDto> GetCourse(int courseId);
        Task<GetCourseDto> UpdateCourse(UpdateCourseDto editCourseDto);
    }
}

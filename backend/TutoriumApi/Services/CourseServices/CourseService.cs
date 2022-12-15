using System.Security.Claims;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tutorium.Data;
using tutorium.Dtos.CourseDto;
using tutorium.Models;
using tutorium.Exceptions;
using tutorium.Utils;

namespace tutorium.Services.CourseServices
{
    public class CourseService : ICourseService
    {
        private readonly TutoriumContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public CourseService(IMapper mapper, TutoriumContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        // private int? GetUserId() => int.Parse(_httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        private int? GetUserId() => 4;

        public async Task<GetCourseDto> CreateCourse(CreateCourseDto createCourseDto)
        {
            Tutor? tutor = await _context.Tutors
                .Include(t => t.Courses)
                .FirstOrDefaultAsync(t => t.Id == GetUserId());

            if (tutor == null)
            {
                throw new UnauthorizedException("User is not tutor");
            }
            if (createCourseDto.Duration % 15 != 0 && createCourseDto.Duration > 0)
            {
                throw new BadRequestException("Course duration should be divisible by 15 (in minutes)");
            }

            Course newCourse = new Course
            {
                Description = createCourseDto.Description,
                Duration = createCourseDto.Duration,
                Name = createCourseDto.Name,
                Subject = createCourseDto.Subject,  // This should automatically controlled. Check it.
                VerifiedStatus = Enum.IsDefined(typeof(VerifableCourseName), createCourseDto.Name) ? VerifiedStatusType.NotVerified : VerifiedStatusType.NotVerifable, // Check if correct
                AffilatedTutor = tutor,
                AffilatedTutorId = tutor.Id // Check if correct
            };

            await _context.Courses.AddAsync(newCourse);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetCourseDto>(newCourse);
        }


        public async Task DeleteCourse(int courseId)
        {
            Course? course = await _context.Courses
                .FirstOrDefaultAsync(c => c.Id == courseId);

            if (course == null)
            {
                throw new NotFoundException("No such course");
            }

            if (course.AffilatedTutorId != GetUserId())
            {
                throw new UnauthorizedException("User does not own the course");
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }

        public async Task<GetCourseDto> GetCourse(int courseId)
        {
            Course? course = await _context.Courses
                .Include(c => c.Bookings)
                .Include(c => c.Materials)
                .Include(c => c.Reviews)
                .FirstOrDefaultAsync(c => c.Id == courseId);

            if (course == null)
            {
                throw new NotFoundException("No such course");
            }

            return _mapper.Map<GetCourseDto>(course);
        }

        public async Task<GetCourseDto> UpdateCourse(UpdateCourseDto updateCourseDto)
        {
            User? tutor = await _context.Tutors
                .Include(t => t.Courses)
                .FirstOrDefaultAsync(t => t.Id == GetUserId());

            if (tutor == null)
                throw new UnauthorizedException("User does not exists.");

            if (updateCourseDto.Duration % 15 != 0 && updateCourseDto.Duration > 0)
                throw new BadRequestException("Course duration should be divisible by 15 (in minutes)");

            Course? course = await _context.Courses
                .FirstOrDefaultAsync(c => c.Id == updateCourseDto.Id);

            if (course == null)
                throw new NotFoundException("No such course");

            if (course.AffilatedTutorId != tutor.Id)
                throw new UnauthorizedException("User does not own the course");

            Patcher.Patch(course, updateCourseDto);

            _context.Courses.Update(course);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetCourseDto>(course);
        }

    }
}

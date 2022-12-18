using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tutorium.Data;
using tutorium.Dtos.CourseDto;
using tutorium.Models;
using tutorium.Exceptions;
using tutorium.Utils;

namespace tutorium.Services.CourseService
{
    public class CourseService : ICourseService
    {
        private readonly TutoriumContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public CourseService(TutoriumContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        private int? GetUserId() => 4;

        public async Task<GetCourseDto> CreateCourse(CreateCourseDto createCourseDto)
        {
            User? tutor = await _context.SUsers
                .Include(t => t.Courses)
                .FirstOrDefaultAsync(t => t.Id == GetUserId());

            if (tutor == null)
            {
                throw new UnauthorizedException("Only tutors can create a course");
            }
            if (tutor.Courses.Any(c => c.Name == createCourseDto.Name))
            {
                throw new BadRequestException("Course with same name already exists for given tutor");
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
                Subject = createCourseDto.Subject,
                VerifiedStatus = Enum.IsDefined(typeof(VerifableCourseName), createCourseDto.Name) ? VerifiedStatusType.NotVerified : VerifiedStatusType.NotVerifable,
                AffilatedTutorId = tutor.Id
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
                throw new UnauthorizedException("Tutor does not own the course");
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }

        public async Task<GetCourseDto> GetCourse(int courseId)
        {
            Course? course = await _context.Courses  // TODO: Check access granularity
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

        public async Task<GetCourseDto> UpdateCourse(int courseId, UpdateCourseDto updateCourseDto)
        {
            Course? course = await _context.Courses
                .FirstOrDefaultAsync(c => c.Id == courseId);

            if (course == null)
                throw new NotFoundException("No such course.");
            if (course.AffilatedTutorId != GetUserId())
                throw new UnauthorizedException("Tutor does not own the course.");
            if (updateCourseDto.Duration % 15 != 0 && updateCourseDto.Duration > 0)
                throw new BadRequestException("Course duration should be divisible by 15 (in minutes)");

            Patcher.Patch(course, updateCourseDto);

            _context.Courses.Update(course);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetCourseDto>(course);
        }

    }
}

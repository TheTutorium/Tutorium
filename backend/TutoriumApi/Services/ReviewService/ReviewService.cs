using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tutorium.Services.ReviewService;
using tutorium.Models;
using tutorium.Exceptions;
using tutorium.Utils;
using tutorium.Data;
using tutorium.Dtos.ReviewDto;

namespace tutorium.Services.CourseService
{
    public class ReviewService : IReviewService
    {
        private readonly TutoriumContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public ReviewService(TutoriumContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<GetReviewDto> CreateReview(CreateReviewDto createReviewDto)
        {
            User? student = await _context.SUsers
                .Where(s => s.Id == Utils.Utility.GetUserId(_httpContextAccessor))
                .Include(s => s.Bookings)
                .Include(s => s.Reviews)
                .FirstOrDefaultAsync();

            decimal rating = Math.Round(createReviewDto.Rating, 1);

            if (student == null)
            {
                throw new UnauthorizedException("Only students can add a review.");
            }
            if (!student.Bookings
                    .Any(booking => booking.AffilatedCourseId == createReviewDto.AffilatedCourseId))
            {
                throw new BadRequestException("Student has not attended to course yet.");
            }
            if (student.Reviews.Any(review => review.AffilatedCourseId == createReviewDto.AffilatedCourseId))
            {
                throw new BadRequestException("Student has already reviewed this course.");
            }
            if (rating < 0 || rating > 10)
            {
                throw new BadRequestException("Rating should be between 0 and 10.");
            }

            Review newReview = new Review
            {
                Comment = createReviewDto.Comment,
                CreatedAt = DateTime.UtcNow,
                Rating = rating,
                AffilatedCourseId = createReviewDto.AffilatedCourseId,
                AffilatedStudentId = student.Id,
            };

            await _context.Reviews.AddAsync(newReview);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetReviewDto>(newReview);
        }


        public async Task DeleteReview(int reviewId)
        {
            Review? review = await _context.Reviews
                .FirstOrDefaultAsync(r => r.Id == reviewId);

            if (review == null)
            {
                throw new NotFoundException("No such review.");
            }
            if (review.AffilatedStudentId != Utils.Utility.GetUserId(_httpContextAccessor))
            {
                throw new UnauthorizedException("This review does not belong to current student.");
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
        }

        public async Task<GetReviewDto> UpdateReview(int reviewId, UpdateReviewDto updateReviewDto)
        {
            Review? review = await _context.Reviews
                .FirstOrDefaultAsync(r => r.Id == reviewId);

            if (review == null)
                throw new NotFoundException("There is no such review.");
            if (review.AffilatedStudentId != Utils.Utility.GetUserId(_httpContextAccessor))
                throw new BadRequestException("This review does not belong to current student.");
            if (updateReviewDto.Rating != null)
            {
                decimal rating = Math.Round((decimal)updateReviewDto.Rating, 1);
                if (rating < 0 || rating > 10)
                {
                    throw new BadRequestException("Rating should be between 0 and 10.");
                }
            }

            Patcher.Patch(review, updateReviewDto);
            review.UpdatedAt = DateTime.UtcNow;

            _context.Reviews.Update(review);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetReviewDto>(review);
        }

    }
}

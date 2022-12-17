using tutorium.Dtos.ReviewDto;

namespace tutorium.Services.ReviewService
{
    public interface IReviewService
    {
        Task<GetReviewDto> CreateReview(CreateReviewDto createReviewDto);
        Task DeleteReview(int reviewId);
        Task<GetReviewDto> UpdateReview(int reviewId, UpdateReviewDto updateReviewDto);
    }
}

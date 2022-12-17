namespace tutorium.Dtos.ReviewDto
{
    public class CreateReviewDto
    {
        public string Comment { get; set; } = null!;
        public decimal Rating { get; set; }

        public int AffilatedCourseId { get; set; }
    }
}

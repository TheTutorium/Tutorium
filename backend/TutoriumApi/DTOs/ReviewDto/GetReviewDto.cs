namespace tutorium.Dtos.ReviewDto
{
    public class GetReviewDto
    {
        public int Id { get; set; }

        public string Comment { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public decimal Rating { get; set; }

        public int AffilatedCourseId { get; set; }
        public int AffilatedStudentId { get; set; }
    }
}

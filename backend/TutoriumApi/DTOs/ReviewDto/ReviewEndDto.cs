namespace tutorium.Dtos.ReviewDto
{
    public class ReviewEndDto
    {
        public int Id { get; set; }

        public string Comment { get; set; } = null!;
        public DateTime? Date { get; set; }
        public decimal Rating { get; set; }

        public int AffilatedCourseId { get; set; }
        public int AffilatedStudentId { get; set; }
    }
}

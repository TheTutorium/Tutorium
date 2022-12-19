namespace tutorium.Dtos.MaterialDto
{
    public class GetMaterialDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string FilePath { get; set; } = null!;
        public DateTime? UpdatedAt { get; set; }

        public int AffilatedCourseId { get; set; }
    }
}

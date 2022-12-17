namespace tutorium.Dtos.MaterialDto
{
    public class CreateMaterialDto
    {
        public string Description { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public IFormFile File { get; set; } = null!;

        public int AffilatedCourseId { get; set; }
    }
}

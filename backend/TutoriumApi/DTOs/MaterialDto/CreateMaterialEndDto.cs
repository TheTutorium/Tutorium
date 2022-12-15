namespace tutorium.Dtos.MaterialDto
{
    public class CreateMaterialEndDto
    {
        public string FilePath { get; set; } = null!;

        public int AffilatedCourseId { get; set; }
    }
}

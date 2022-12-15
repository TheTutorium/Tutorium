namespace tutorium.Dtos.MaterialDto
{
    public class MaterialEndDto
    {
        public int Id { get; set; }
        public string FilePath { get; set; } = null!;

        public int AffilatedCourseId { get; set; }
    }
}

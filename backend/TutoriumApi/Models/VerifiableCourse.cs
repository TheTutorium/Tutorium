namespace tutorium.Models
{
    public class VerifableCourse : Course
    {
        // Attributes
        public string? DocumentPath { get; set; }
        public bool VerifiedStatus { get; set; }
    }

    static class VerifableCourseTypes
    {
        public const string YKS = "YKS";
    }
}

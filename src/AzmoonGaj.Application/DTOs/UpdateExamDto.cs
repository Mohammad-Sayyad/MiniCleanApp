namespace AzmoonGaj.Application.DTOs
{
    public class UpdateExamDto
    {
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime ExamDate { get; set; }

        public int Duration { get; set; }

        public bool IsActive { get; set; }
    }
}

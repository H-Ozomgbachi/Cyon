namespace Cyon.Domain.Entities
{
    public class Announcement : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; } = true;
        public string ReadBy { get; set; } = string.Empty;
        public string ModifiedBy { get; set; }
        public DateTime ImportantDate { get; set; } = DateTime.MinValue;
    }
}

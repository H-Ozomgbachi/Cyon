namespace Cyon.Domain.Entities
{
    public class Announcement : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsActive { get; set; } = true;
        public Guid ModifiedBy { get; set; }
    }
}

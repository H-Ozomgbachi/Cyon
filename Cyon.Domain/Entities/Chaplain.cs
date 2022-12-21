namespace Cyon.Domain.Entities
{
    public class Chaplain : BaseEntity
    {
        public string Fullname { get; set; }
        public string ImageUrl { get; set; }
        public string StartYear { get; set; }
        public string EndYear { get; set; }
        public DateTime DateAdded { get; set; }
        public Guid ModifiedBy { get; set; }
    }
}

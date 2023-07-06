namespace Cyon.Domain.Entities
{
    public class Chaplain : BaseEntity
    {
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public string StartYear { get; set; }
        public string EndYear { get; set; }
        public Guid ModifiedBy { get; set; }
    }
}

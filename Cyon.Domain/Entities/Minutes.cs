namespace Cyon.Domain.Entities
{
    public class Minutes : BaseEntity
    {
        public string Content { get; set; }
        public DateTime DateOfMeeting { get; set; }
        public Guid ModifiedBy { get; set; }
    }
}

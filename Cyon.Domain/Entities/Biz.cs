namespace Cyon.Domain.Entities
{
    public class Biz : BaseEntity
    {
        public string BusinessName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string PhysicalAddress { get; set; }
        public bool IsActive { get; set; }
    }
}
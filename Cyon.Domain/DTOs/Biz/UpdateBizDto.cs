namespace Cyon.Domain.DTOs.Biz
{
    public class UpdateBizDto
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string PhysicalAddress { get; set; }
    }
}
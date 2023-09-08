namespace Cyon.Domain.Models.Biz
{
    public class BizModel
    {
        public Guid Id { get; set; }
        public string BusinessName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string PhysicalAddress { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
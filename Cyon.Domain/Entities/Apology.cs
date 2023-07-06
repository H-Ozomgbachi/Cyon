namespace Cyon.Domain.Entities
{
    public class Apology : BaseEntity
    {
        public string For { get; set; }
        public Guid AttendanceTypeId { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }
        public bool IsRejected { get; set; } = false;
        public string RejectionReason { get; set; } = string.Empty;
        public bool IsResolved { get; set; } = false;
        public string UserCode { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
    }
}

namespace Cyon.Domain.Models.Attendance
{
    public class ApologyModel
    {
        public Guid Id { get; set; }
        public string For { get; set; }
        public Guid AttendanceTypeId { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }
        public bool IsRejected { get; set; }
        public string RejectionReason { get; set; }
        public bool IsResolved { get; set; }
        public Guid UserId { get; set; }
        public string UserEmail { get; set; }
    }
}

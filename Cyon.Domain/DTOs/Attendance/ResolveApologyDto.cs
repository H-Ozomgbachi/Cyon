namespace Cyon.Domain.DTOs.Attendance
{
    public class ResolveApologyDto
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
        public string UserCode { get; set; }
        public string Name { get; set; }
    }
}

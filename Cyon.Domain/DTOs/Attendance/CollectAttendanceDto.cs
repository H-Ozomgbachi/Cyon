namespace Cyon.Domain.DTOs.Attendance
{
    public class CollectAttendanceDto
    {
        public Guid AttendanceTypeId { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<AttendanceDatum> AttendanceData { get; set; }
    }

    public class AttendanceDatum
    {
        public Guid UserId { get; set; }
        public ushort Rating { get; set; }
        public string UserEmail { get; set; }
    }
}

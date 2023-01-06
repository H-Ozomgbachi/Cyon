namespace Cyon.Domain.DTOs.Attendance
{
    public class MarkAbsentDto
    {
        public DateTime DateEventHeld { get; set; }
        public Guid AttendanceTypeId { get; set; }
    }
}

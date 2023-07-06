namespace Cyon.Domain.DTOs.Attendance
{
    public class CreateApologyDto
    {
        public Guid AttendanceTypeId { get; set; }
        public string AbsenteeReason { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
    }
}

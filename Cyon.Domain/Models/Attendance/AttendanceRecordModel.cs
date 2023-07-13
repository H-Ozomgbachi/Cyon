namespace Cyon.Domain.Models.Attendance
{
    public class AttendanceRecordModel
    {
        public string AttendanceTypeName { get; set; }
        public List<AttendanceRegisterModel> Attendances { get; set; }
    }
}

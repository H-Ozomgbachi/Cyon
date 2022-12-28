using System.Text.Json.Serialization;

namespace Cyon.Domain.DTOs.Attendance
{
    public class CreateApologyDto
    {
        public Guid AttendanceTypeId { get; set; }
        public string AbsenteeReason { get; set; }
        public DateTime Date { get; set; }
        [JsonIgnore]
        public string UserEmail { get; set; }
    }
}

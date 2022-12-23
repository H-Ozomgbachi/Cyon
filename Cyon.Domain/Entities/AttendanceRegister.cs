namespace Cyon.Domain.Entities
{
    public partial class AttendanceRegister : BaseEntity
    {
        public Guid AttendanceTypeId { get; set; }
        public string AttendanceTypeName { get; set; }
        public DateTime DateAdded { get; set; }
        public Guid UserId { get; set; }
        public string UserEmail { get; set; }
        public bool IsPresent { get; set; }
        public ushort Rating { get; set; }
    }
}

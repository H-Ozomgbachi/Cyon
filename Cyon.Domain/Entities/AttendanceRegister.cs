namespace Cyon.Domain.Entities
{
    public partial class AttendanceRegister : BaseEntity
    {
        public Guid AttendanceTypeId { get; set; }
        public string AttendanceTypeName { get; set; }
        public string UserCode { get; set; }
        public string Name { get; set; }
        public bool IsPresent { get; set; }
        public ushort Rating { get; set; }
    }
}

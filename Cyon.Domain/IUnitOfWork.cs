using Cyon.Domain.Repositories;

namespace Cyon.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IChaplainRepository ChaplainRepository { get; }
        IMinutesRepository MinutesRepository { get; }
        IAnnouncementRepository AnnouncementRepository { get; }
        IMeetingRepository MeetingRepository { get; }
        IAgendumRepository AgendumRepository { get; }
        IAttendanceTypeRepository AttendanceTypeRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        Task<int> SaveAsync();
    }
}

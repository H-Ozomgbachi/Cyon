using Cyon.Domain.Entities;
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
        IOccupationRepository OccupationRepository { get; }
        IAttendanceRegisterRepository AttendanceRegisterRepository { get; }
        IApologyRepository ApologyRepository { get; }
        IDeactivateRequestRepository DeactivateRequestRepository { get; }
        IUserFinanceRepository UserFinanceRepository { get; }
        IOrganisationFinanceRepository OrganisationFinanceRepository { get; }
        Task<int> SaveAsync();
    }
}

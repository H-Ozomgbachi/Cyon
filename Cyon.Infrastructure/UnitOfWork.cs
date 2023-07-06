using Cyon.Domain;
using Cyon.Domain.Repositories;
using Cyon.Infrastructure.Database;
using Cyon.Infrastructure.Repositories;

namespace Cyon.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly DapperContext _dapperContext;
        private IChaplainRepository _chaplainRepository;
        private IMinutesRepository _minutesRepository;
        private IAnnouncementRepository _announcementRepository;
        private IMeetingRepository _meetingRepository;
        private IAgendumRepository _agendumRepository;
        private IAttendanceTypeRepository _attendanceTypeRepository;
        private IDepartmentRepository _departmentRepository;
        private IOccupationRepository _occupationRepository;
        private IAttendanceRegisterRepository _attendanceRegisterRepository;
        private IApologyRepository _apologyRepository;
        private IDeactivateRequestRepository _deactivateRequestRepository;
        private IUserFinanceRepository _userFinanceRepository;
        private IOrganisationFinanceRepository _organisationFinanceRepository;
        private IYearProgrammeRepository _yearProgrammeRepository;
        private IUpcomingEventRepository _upcomingEventRepository;
        private IDecisionRepository _decisionRepository;
        private IDecisionResponseRepository _decisionResponseRepository;

        public UnitOfWork(AppDbContext dbContext, DapperContext dapperContext)
        {
            _dbContext = dbContext;
            _dapperContext = dapperContext;
        }

        public IChaplainRepository ChaplainRepository
        {
            get
            {
                if (_chaplainRepository == null)
                {
                    _chaplainRepository = new ChaplainRepository(_dbContext.Chaplains);

                    return _chaplainRepository;
                }
                return _chaplainRepository;
            }
        }

        public IMinutesRepository MinutesRepository
        {
            get
            {
                if (_minutesRepository == null)
                {
                    _minutesRepository = new MinutesRepository(_dbContext.Minutes);

                    return _minutesRepository;
                }
                return _minutesRepository;
            }
        }

        public IAnnouncementRepository AnnouncementRepository
        {
            get
            {
                if (_announcementRepository == null)
                {
                    _announcementRepository = new AnnouncementRepository(_dbContext.Announcements);

                    return _announcementRepository;
                }
                return _announcementRepository;
            }
        }

        public IMeetingRepository MeetingRepository
        {
            get
            {
                if (_meetingRepository == null)
                {
                    _meetingRepository = new MeetingRepository(_dbContext.Meetings);

                    return _meetingRepository;
                }
                return _meetingRepository;
            }
        }

        public IAgendumRepository AgendumRepository
        {
            get
            {
                if (_agendumRepository == null)
                {
                    _agendumRepository = new AgendumRepository(_dbContext.Agenda);

                    return _agendumRepository;
                }
                return _agendumRepository;
            }
        }

        public IAttendanceTypeRepository AttendanceTypeRepository
        {
            get
            {
                if (_attendanceTypeRepository == null)
                {
                    _attendanceTypeRepository = new AttendanceTypeRepository(_dbContext.AttendanceTypes);

                    return _attendanceTypeRepository;
                }
                return _attendanceTypeRepository;
            }
        }

        public IDepartmentRepository DepartmentRepository
        {
            get
            {
                if (_departmentRepository == null)
                {
                    _departmentRepository = new DepartmentRepository(_dbContext.Departments);

                    return _departmentRepository;
                }
                return _departmentRepository;
            }
        }

        public IOccupationRepository OccupationRepository
        {
            get
            {
                if (_occupationRepository == null)
                {
                    _occupationRepository = new OccupationRepository(_dbContext.Occupations, _dapperContext);

                    return _occupationRepository;
                }
                return _occupationRepository;
            }
        }

        public IAttendanceRegisterRepository AttendanceRegisterRepository
        {
            get
            {
                if (_attendanceRegisterRepository == null)
                {
                    _attendanceRegisterRepository = new AttendanceRegisterRepository(_dbContext.AttendanceRegisters, _dapperContext);

                    return _attendanceRegisterRepository;
                }
                return _attendanceRegisterRepository;
            }
        }

        public IApologyRepository ApologyRepository
        {
            get
            {
                if (_apologyRepository == null)
                {
                    _apologyRepository = new ApologyRepository(_dbContext.Apologies, _dapperContext);

                    return _apologyRepository;
                }
                return _apologyRepository;
            }
        }

        public IDeactivateRequestRepository DeactivateRequestRepository
        {
            get
            {
                if (_deactivateRequestRepository == null)
                {
                    _deactivateRequestRepository = new DeactivateRequestRepository(_dbContext.DeactivateRequests);

                    return _deactivateRequestRepository;
                }
                return _deactivateRequestRepository;
            }
        }
        public IUserFinanceRepository UserFinanceRepository
        {
            get
            {
                if (_userFinanceRepository == null)
                {
                    _userFinanceRepository = new UserFinanceRepository(_dbContext.UserFinances, _dapperContext);

                    return _userFinanceRepository;
                }
                return _userFinanceRepository;
            }
        }

        public IOrganisationFinanceRepository OrganisationFinanceRepository
        {
            get
            {
                if (_organisationFinanceRepository == null)
                {
                    _organisationFinanceRepository = new OrganisationFinanceRepository(_dbContext.OrganisationFinances, _dapperContext);

                    return _organisationFinanceRepository;
                }
                return _organisationFinanceRepository;
            }
        }

        public IYearProgrammeRepository YearProgrammeRepository
        {
            get
            {
                if (_yearProgrammeRepository == null)
                {
                    _yearProgrammeRepository = new YearProgrammeRepository(_dbContext.YearProgrammes);

                    return _yearProgrammeRepository;
                }
                return _yearProgrammeRepository;
            }
        }

        public IUpcomingEventRepository UpcomingEventRepository
        {
            get
            {
                if (_upcomingEventRepository == null)
                {
                    _upcomingEventRepository = new UpcomingEventRepository(_dbContext.UpcomingEvents);

                    return _upcomingEventRepository;
                }
                return _upcomingEventRepository;
            }
        }

        public IDecisionRepository DecisionRepository
        {
            get
            {
                if (_decisionRepository == null)
                {
                    _decisionRepository = new DecisionRepository(_dbContext.Decisions);
                    return _decisionRepository;
                }
                return _decisionRepository;
            }
        }
        public IDecisionResponseRepository DecisionResponseRepository
        {
            get
            {
                if (_decisionResponseRepository == null)
                {
                    _decisionResponseRepository = new DecisionResponseRepository(_dbContext.DecisionResponses);
                    return _decisionResponseRepository;
                }
                return _decisionResponseRepository;
            }
        }
        public void Dispose() => _dbContext.Dispose();

        public async Task<int> SaveAsync() => await _dbContext.SaveChangesAsync();
    }
}

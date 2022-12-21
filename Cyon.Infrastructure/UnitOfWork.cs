﻿using Cyon.Domain;
using Cyon.Domain.Repositories;
using Cyon.Infrastructure.Database;
using Cyon.Infrastructure.Repositories;

namespace Cyon.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private IChaplainRepository _chaplainRepository;
        private IMinutesRepository _minutesRepository;
        private IAnnouncementRepository _announcementRepository;
        private IMeetingRepository _meetingRepository;
        private IAgendumRepository _agendumRepository;
        private IAttendanceTypeRepository _attendanceTypeRepository;
        private IDepartmentRepository _departmentRepository;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
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
        public void Dispose() => _dbContext.Dispose();

        public async Task<int> SaveAsync() => await _dbContext.SaveChangesAsync();
    }
}

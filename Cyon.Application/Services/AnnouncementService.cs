﻿using AutoMapper;
using Cyon.Domain;
using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Announcement;
using Cyon.Domain.Entities;
using Cyon.Domain.Exceptions;
using Cyon.Domain.Models.Announcement;
using Cyon.Domain.Services;

namespace Cyon.Application.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AnnouncementService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AnnouncementModel> AddAnnouncement(CreateAnnouncementDto announcementDto, Guid modifiedBy)
        {
            Announcement announcement = _mapper.Map<Announcement>(announcementDto);
            announcement.ModifiedBy = modifiedBy;

            await _unitOfWork.AnnouncementRepository.AddAsync(announcement);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<AnnouncementModel>(announcement);
        }

        public async Task DeleteAnnouncement(Guid announcementId)
        {
            bool exists = await _unitOfWork.AnnouncementRepository.ExistAsync(x => x.Id == announcementId);

            if (exists == false)
            {
                throw new NotFoundException("Announcement does not exist");
            }

            Announcement announcement = await _unitOfWork.AnnouncementRepository.GetByIdAsync(announcementId);
            await _unitOfWork.AnnouncementRepository.DeleteAsync(announcement);
            await _unitOfWork.SaveAsync();
        }

        public async Task<AnnouncementModel> GetAnnouncement(Guid announcementId)
        {
            bool exists = await _unitOfWork.AnnouncementRepository.ExistAsync(x => x.Id.Equals(announcementId));
            if (exists == false)
            {
                throw new NotFoundException("Announcement was not found");
            }

            Announcement announcement = await _unitOfWork.AnnouncementRepository.GetByIdAsync(announcementId);

            return _mapper.Map<AnnouncementModel>(announcement);
        }

        public async Task<IEnumerable<AnnouncementModel>> GetAnnouncements(Pagination pagination)
        {
            IEnumerable<Announcement> announcements = await _unitOfWork.AnnouncementRepository.GetAllAsync(pagination.Skip, pagination.Limit);

            return _mapper.Map<IEnumerable<AnnouncementModel>>(announcements);
        }

        public async Task UpdateAnnouncement(UpdateAnnouncementDto announcementDto, Guid modifiedBy)
        {
            bool exists = await _unitOfWork.AnnouncementRepository.ExistAsync(x => x.Id == announcementDto.Id);

            if (!exists)
            {
                throw new NotFoundException("Announcement doesn't exist");
            }

            Announcement announcement = _mapper.Map<Announcement>(announcementDto);
            await _unitOfWork.AnnouncementRepository.UpdateAsync(announcement);
            await _unitOfWork.SaveAsync();
        }
    }
}

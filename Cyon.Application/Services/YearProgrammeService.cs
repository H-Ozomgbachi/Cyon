using AutoMapper;
using Cyon.Domain;
using Cyon.Domain.Common;
using Cyon.Domain.DTOs.YearProgramme;
using Cyon.Domain.Entities;
using Cyon.Domain.Exceptions;
using Cyon.Domain.Models.YearProgramme;
using Cyon.Domain.Services;

namespace Cyon.Application.Services
{
    public class YearProgrammeService : IYearProgrammeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;

        public YearProgrammeService(IUnitOfWork unitOfWork, IMapper mapper, IPhotoService photoService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _photoService = photoService;
        }

        public async Task<YearProgrammeModel> AddYearProgramme(CreateYearProgrammeDto createYearProgrammeDto)
        {
            string imageUrl = await _photoService.UploadOneImage(createYearProgrammeDto.Image);

            YearProgramme yearProgramme = _mapper.Map<YearProgramme>(createYearProgrammeDto);
            yearProgramme.ImageUrl = imageUrl;

            await _unitOfWork.YearProgrammeRepository.AddAsync(yearProgramme);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<YearProgrammeModel>(yearProgramme);
        }

        public async Task DeleteYearProgramme(Guid id)
        {
            var yearProgramme = await _unitOfWork.YearProgrammeRepository.GetByIdAsync(id);

            if (yearProgramme == null)
            {
                throw new NotFoundException("Year programme was not found");
            }

            _unitOfWork.YearProgrammeRepository.Delete(yearProgramme);
            await _unitOfWork.SaveAsync();
        }

        public async Task<YearProgrammeModel> GetYearProgrammeById(Guid id)
        {
            var yearProgramme = await _unitOfWork.YearProgrammeRepository.GetByIdAsync(id);
            if (yearProgramme == null)
            {
                throw new NotFoundException("Year programme was not found");
            }
            return _mapper.Map<YearProgrammeModel>(yearProgramme);
        }

        public async Task<IEnumerable<YearProgrammeModel>> GetYearProgrammes(Pagination pagination)
        {
            IEnumerable<YearProgramme> yearProgrammes = await _unitOfWork.YearProgrammeRepository.GetAllAsync(pagination.Skip, pagination.Limit);

            return _mapper.Map<IEnumerable<YearProgrammeModel>>(yearProgrammes);
        }

        public async Task UpdateYearProgramme(UpdateYearProgrammeDto updateYearProgrammeDto)
        {
            var yearProgramme = await _unitOfWork.YearProgrammeRepository.GetByIdAsync(updateYearProgrammeDto.Id);

            if (yearProgramme == null)
            {
                throw new NotFoundException("Year programme was not found");
            }

            _mapper.Map(updateYearProgrammeDto, yearProgramme);
            await _unitOfWork.YearProgrammeRepository.UpdateAsync(yearProgramme);
            await _unitOfWork.SaveAsync();
        }
    }
}

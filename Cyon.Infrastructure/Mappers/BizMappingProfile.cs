using AutoMapper;
using Cyon.Domain.DTOs.Biz;
using Cyon.Domain.Entities;
using Cyon.Domain.Models.Biz;

namespace Cyon.Infrastructure.Mappers
{
    public class BizMappingProfile : Profile
    {
        public BizMappingProfile()
        {
            CreateMap<Biz, CreateBizDto>().ReverseMap();
            CreateMap<Biz, UpdateBizDto>().ReverseMap();
            CreateMap<Biz, BizModel>().ReverseMap();

            CreateMap<BizCategory, CreateBizCategoryDto>().ReverseMap();
            CreateMap<BizCategory, BizCategoryModel>().ReverseMap();

            CreateMap<BizProduct, CreateBizProductDto>().ReverseMap();
            CreateMap<BizProduct, UpdateBizProductDto>().ReverseMap();
            CreateMap<BizProductModel, BizProduct>().ReverseMap();

            CreateMap<BizProductReview, CreateBizProductReviewDto>().ReverseMap();
            CreateMap<BizProductReview, BizProductReviewModel>().ReverseMap();

            CreateMap<BizProductTransaction, CreateBizProductTransactionDto>().ReverseMap();
            CreateMap<BizProductTransaction, UpdateBizProductTransactionDto>().ReverseMap();
            CreateMap<BizProductTransaction, BizProductTransactionModel>().ReverseMap();
        }
    }
}
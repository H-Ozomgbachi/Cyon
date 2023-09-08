using Cyon.Domain.DTOs.Biz;
using FluentValidation;

namespace Cyon.Infrastructure.Validators.Biz
{
    public class CreateBizCategoryDtoValidator : AbstractValidator<CreateBizCategoryDto>
    {
        public CreateBizCategoryDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}

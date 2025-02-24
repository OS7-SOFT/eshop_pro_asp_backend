
using EShopPro.Application.Features.Categories.Queries;
using FluentValidation;

namespace EShopPro.Application.Features.validators
{
    public class GetCategoryByIdValidator:AbstractValidator<GetCategoryByIdQuery>
    {
        public GetCategoryByIdValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty().WithMessage("id should not be null or empty")
               .NotEqual(Guid.Empty).WithMessage("id is faild");
        }
    }
}
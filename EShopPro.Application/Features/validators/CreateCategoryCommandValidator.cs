using EShopPro.Application.Features.Categories.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopPro.Application.Features.validators
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            //CascadeMode = CascadeMode.Stop;

            RuleFor(command=>command.Name)
                .NotEmpty()
                .WithMessage("Name is Required");
            RuleFor(command => command.Description)
                .NotEmpty()
                .WithMessage("Description is Required")
                .MinimumLength(20).WithMessage("The Description can not be less than 20 character");
        }
    }
}

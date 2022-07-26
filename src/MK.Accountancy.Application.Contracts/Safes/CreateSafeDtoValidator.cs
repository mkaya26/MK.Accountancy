using FluentValidation;
using Microsoft.Extensions.Localization;
using MK.Accountancy.Consts;
using MK.Accountancy.Localization;
using System;

namespace MK.Accountancy.Safes
{
    public class CreateSafeDtoValidator : AbstractValidator<CreateSafeDto>
    {
        public CreateSafeDtoValidator(IStringLocalizer<AccountancyResource> localizer)
        {
            RuleFor(x => x.Code)
                .NotEmpty()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["Code"]])
                .MaximumLength(EntityConst.MaxCodeLength)
                .WithMessage(localizer[AccountancyDomainErrorCodes.MaxLength, localizer["Code"], EntityConst.MaxCodeLength]);
            //
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["Name"]])
                .MaximumLength(EntityConst.MaxNameLength)
                .WithMessage(localizer[AccountancyDomainErrorCodes.MaxLength, localizer["Name"], EntityConst.MaxNameLength]);
            //
            RuleFor(x => x.DepartmentId)
                .Must(x => x.HasValue && x.Value != Guid.Empty)
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["Department"]]);
            //
            RuleFor(x => x.Description)
                .MaximumLength(EntityConst.MaxDescriptionLength)
                .WithMessage(localizer[AccountancyDomainErrorCodes.MaxLength, localizer["Description"], EntityConst.MaxDescriptionLength]);
        }
    }
}

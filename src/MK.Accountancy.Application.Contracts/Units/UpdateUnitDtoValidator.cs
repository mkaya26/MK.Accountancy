using FluentValidation;
using Microsoft.Extensions.Localization;
using MK.Accountancy.Consts;
using MK.Accountancy.Localization;

namespace MK.Accountancy.Units
{
    public class UpdateUnitDtoValidator : AbstractValidator<UpdateUnitDto>
    {
        public UpdateUnitDtoValidator(IStringLocalizer<AccountancyResource> localizer)
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
            RuleFor(x => x.Description)
                .MaximumLength(EntityConst.MaxDescriptionLength)
                .WithMessage(localizer[AccountancyDomainErrorCodes.MaxLength, localizer["Description"], EntityConst.MaxDescriptionLength]);

        }
    }
}

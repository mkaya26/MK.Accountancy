using FluentValidation;
using Microsoft.Extensions.Localization;
using MK.Accountancy.Consts;
using MK.Accountancy.Localization;

namespace MK.Accountancy.SpecialCodes
{
    public class CreateSpecialCodeDtoValidator : AbstractValidator<CreateSpecialCodeDto>
    {
        public CreateSpecialCodeDtoValidator(IStringLocalizer<AccountancyResource> localizer)
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
            RuleFor(x => x.SpecialCodeType)
                .IsInEnum()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["SpecialCodeType"]])
                .NotEmpty()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["SpecialCodeType"]]);
            //
            RuleFor(x => x.CardType)
                .IsInEnum()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["CardType"]])
                .NotEmpty()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["CardType"]]);
            //
            RuleFor(x => x.Description)
                .MaximumLength(EntityConst.MaxDescriptionLength)
                .WithMessage(localizer[AccountancyDomainErrorCodes.MaxLength, localizer["Description"], EntityConst.MaxDescriptionLength]);
        }
    }
}

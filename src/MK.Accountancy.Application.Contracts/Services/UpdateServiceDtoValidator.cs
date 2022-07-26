using FluentValidation;
using Microsoft.Extensions.Localization;
using MK.Accountancy.Consts;
using MK.Accountancy.Localization;
using System;

namespace MK.Accountancy.Services
{
    public class UpdateServiceDtoValidator : AbstractValidator<UpdateServiceDto>
    {
        public UpdateServiceDtoValidator(IStringLocalizer<AccountancyResource> localizer)
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
            RuleFor(x => x.UnitId)
                .Must(x => x.HasValue && x.Value != Guid.Empty)
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["Unit"]]);
            //
            RuleFor(x => x.TaxRate)
                .NotNull()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["ValueAddedTaxRate"]])
                .GreaterThanOrEqualTo(0)
                .WithMessage(localizer[AccountancyDomainErrorCodes.GreaterThanOrEqual, localizer["ValueAddedTaxRate"], localizer["ToZero"], localizer["ThanZero"]]);
            //
            RuleFor(x => x.UnitPrice)
                .NotNull()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["UnitPrice"]])
                .GreaterThanOrEqualTo(0)
                .WithMessage(localizer[AccountancyDomainErrorCodes.GreaterThanOrEqual, localizer["UnitPrice"], localizer["ToZero"], localizer["ThanZero"]]);
            //
            RuleFor(x => x.Barcode)
                .MaximumLength(EntityConst.MaxBarcodeLength)
                .WithMessage(localizer[AccountancyDomainErrorCodes.MaxLength, localizer["Barcode"], EntityConst.MaxBarcodeLength]);
            //
            RuleFor(x => x.Description)
                .MaximumLength(EntityConst.MaxDescriptionLength)
                .WithMessage(localizer[AccountancyDomainErrorCodes.MaxLength, localizer["Description"], EntityConst.MaxDescriptionLength]);
        }
    }
}

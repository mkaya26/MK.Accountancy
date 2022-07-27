using FluentValidation;
using Microsoft.Extensions.Localization;
using MK.Accountancy.Consts;
using MK.Accountancy.Localization;
using System;

namespace MK.Accountancy.Invoices
{
    public class UpdateInvoiceDtoValidator : AbstractValidator<UpdateInvoiceDto>
    {
        public UpdateInvoiceDtoValidator(IStringLocalizer<AccountancyResource> localizer)
        {
            RuleFor(x => x.InvoiceNumber)
                .NotEmpty()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["InvoiceNumber"]])
                .MaximumLength(InvoiceConst.MaxInvoiceNumberLength)
                .WithMessage(localizer[AccountancyDomainErrorCodes.MaxLength, localizer["InvoiceNumber"], InvoiceConst.MaxInvoiceNumberLength]);
            //
            RuleFor(x => x.InvoiceDate)
                .NotEmpty()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["Date"]]);
            //
            RuleFor(x => x.GrandTotal)
                .NotNull()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["GrandTotal"]])
                .GreaterThanOrEqualTo(0)
                .WithMessage(localizer[AccountancyDomainErrorCodes.GreaterThanOrEqual, localizer["GrandTotal"], localizer["ToZero"], localizer["ThanZero"]]);
            //
            RuleFor(x => x.DiscountTotal)
                .NotNull()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["DiscountTotal"]])
                .GreaterThanOrEqualTo(0)
                .WithMessage(localizer[AccountancyDomainErrorCodes.GreaterThanOrEqual, localizer["DiscountTotal"], localizer["ToZero"], localizer["ThanZero"]]);
            //
            RuleFor(x => x.SubTotal)
                .NotNull()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["SubTotal"]])
                .GreaterThanOrEqualTo(0)
                .WithMessage(localizer[AccountancyDomainErrorCodes.GreaterThanOrEqual, localizer["SubTotal"], localizer["ToZero"], localizer["ThanZero"]]);
            //
            RuleFor(x => x.TaxAmount)
                .NotNull()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["TaxAmount"]])
                .GreaterThanOrEqualTo(0)
                .WithMessage(localizer[AccountancyDomainErrorCodes.GreaterThanOrEqual, localizer["TaxAmount"], localizer["ToZero"], localizer["ThanZero"]]);
            //
            RuleFor(x => x.SubTotal)
                .NotNull()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["Netamount"]])
                .GreaterThanOrEqualTo(0)
                .WithMessage(localizer[AccountancyDomainErrorCodes.GreaterThanOrEqual, localizer["Netamount"], localizer["ToZero"], localizer["ThanZero"]]);
            //
            RuleFor(x => x.MovementNumber)
                .NotNull()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["MovementNumber"]])
                .GreaterThanOrEqualTo(0)
                .WithMessage(localizer[AccountancyDomainErrorCodes.GreaterThanOrEqual, localizer["MovementNumber"], localizer["ToZero"], localizer["ThanZero"]]);
            //
            RuleFor(x => x.CurrentId)
                .Must(x => x.HasValue && x.Value != Guid.Empty)
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["Current"]]);
            //
            RuleFor(x => x.Description)
                .MaximumLength(EntityConst.MaxDescriptionLength)
                .WithMessage(localizer[AccountancyDomainErrorCodes.MaxLength, localizer["Description"], EntityConst.MaxDescriptionLength]);
            //
            RuleForEach(x => x.InvoiceDetails)
                .SetValidator(y => new InvoiceDetailDtoValidator(localizer));
        }
    }
}

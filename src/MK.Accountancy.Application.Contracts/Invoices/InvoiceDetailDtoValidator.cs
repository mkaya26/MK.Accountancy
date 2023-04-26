using FluentValidation;
using Microsoft.Extensions.Localization;
using MK.Accountancy.Consts;
using System;

namespace MK.Accountancy.Invoices
{
    public class InvoiceDetailDtoValidator : AbstractValidator<InvoiceDetailDto>
    {
        public InvoiceDetailDtoValidator(IStringLocalizer localizer)
        {
            RuleFor(x => x.Id)
                .Must(x => x.HasValue && x.Value != Guid.Empty)
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["Id"]]);
            //
            RuleFor(x => x.InvoiceDetailType)
                .IsInEnum()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["InvoiceDetailType"]])
                .NotEmpty()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["InvoiceDetailType"]]);
            //
            RuleFor(x => x.StockId)
                .NotEmpty()
                .When(x => x.InvoiceDetailType == InvoiceDetailType.Stock)
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["Stock"]]);
            //
            RuleFor(x => x.ServiceId)
                .NotEmpty()
                .When(x => x.InvoiceDetailType == InvoiceDetailType.Service)
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["Service"]]);
            //
            RuleFor(x => x.ExpenseId)
                .NotEmpty()
                .When(x => x.InvoiceDetailType == InvoiceDetailType.Expense)
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["Expense"]]);
            //
            RuleFor(x => x.StoreId)
                .NotEmpty()
                .When(x => x.InvoiceDetailType == InvoiceDetailType.Stock)
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["Store"]]);
            //
            RuleFor(x => x.Quantity)
                .NotNull()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["Quantity"]])
                .GreaterThanOrEqualTo(0)
                .WithMessage(localizer[AccountancyDomainErrorCodes.GreaterThanOrEqual, localizer["Quantity"], localizer["ToZero"], localizer["ThanZero"]]);
            //
            RuleFor(x => x.UnitPrice)
                .NotNull()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["UnitPrice"]])
                .GreaterThanOrEqualTo(0)
                .WithMessage(localizer[AccountancyDomainErrorCodes.GreaterThanOrEqual, localizer["UnitPrice"], localizer["ToZero"], localizer["ThanZero"]]);
            //
            RuleFor(x => x.GrossAmount)
                .NotNull()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["GrossAmount"]])
                .GreaterThanOrEqualTo(0)
                .WithMessage(localizer[AccountancyDomainErrorCodes.GreaterThanOrEqual, localizer["GrossAmount"], localizer["ToZero"], localizer["ThanZero"]]);
            //
            RuleFor(x => x.DiscountAmount)
                .NotNull()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["DiscountAmount"]])
                .GreaterThanOrEqualTo(0)
                .WithMessage(localizer[AccountancyDomainErrorCodes.GreaterThanOrEqual, localizer["DiscountAmount"], localizer["ToZero"], localizer["ThanZero"]]);
            //
            RuleFor(x => x.TaxRate)
                .NotNull()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["TaxRate"]])
                .GreaterThanOrEqualTo(0)
                .WithMessage(localizer[AccountancyDomainErrorCodes.GreaterThanOrEqual, localizer["TaxRate"], localizer["ToZero"], localizer["ThanZero"]]);
            //
            RuleFor(x => x.SubTotal)
                .NotNull()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["SubTotal"]])
                .GreaterThanOrEqualTo(0)
                .WithMessage(localizer[AccountancyDomainErrorCodes.GreaterThanOrEqual, localizer["SubTotal"], localizer["ToZero"], localizer["ThanZero"]]);
            //
            RuleFor(x => x.TaxTotal)
                .NotNull()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["TaxTotal"]])
                .GreaterThanOrEqualTo(0)
                .WithMessage(localizer[AccountancyDomainErrorCodes.GreaterThanOrEqual, localizer["TaxTotal"], localizer["ToZero"], localizer["ThanZero"]]);
            //
            RuleFor(x => x.NetTotal)
                .NotNull()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["NetTotal"]])
                .GreaterThanOrEqualTo(0)
                .WithMessage(localizer[AccountancyDomainErrorCodes.GreaterThanOrEqual, localizer["NetTotal"], localizer["ToZero"], localizer["ThanZero"]]);
            //
            RuleFor(x => x.Description)
                .MaximumLength(EntityConst.MaxDescriptionLength)
                .WithMessage(localizer[AccountancyDomainErrorCodes.MaxLength, localizer["Description"], EntityConst.MaxDescriptionLength]);
        }
    }
}

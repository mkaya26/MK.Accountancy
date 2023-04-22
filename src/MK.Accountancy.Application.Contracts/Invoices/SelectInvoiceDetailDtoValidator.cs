using FluentValidation;
using Microsoft.Extensions.Localization;
using MK.Accountancy.Consts;

namespace MK.Accountancy.Invoices
{
    public class SelectInvoiceDetailDtoValidator : AbstractValidator<SelectInvoiceDetailDto>
    {
        public SelectInvoiceDetailDtoValidator(IStringLocalizer localizer)
        {
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
            RuleFor(x => x.ExpenceId)
                .NotEmpty()
                .When(x => x.InvoiceDetailType == InvoiceDetailType.Expense)
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["Expense"]]);
            //
            RuleFor(x => x.StoreId)
                .NotEmpty()
                .When(x => x.InvoiceDetailType == InvoiceDetailType.Stock)
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["Warehouse"]]);
            //
            RuleFor(x => x.Description)
                .MaximumLength(EntityConst.MaxDescriptionLength)
                .WithMessage(localizer[AccountancyDomainErrorCodes.MaxLength, localizer["Description"], EntityConst.MaxDescriptionLength]);
        }
    }
}

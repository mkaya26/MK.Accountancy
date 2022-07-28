using FluentValidation;
using Microsoft.Extensions.Localization;
using MK.Accountancy.Consts;
using MK.Accountancy.Localization;
using System;

namespace MK.Accountancy.Receipts
{
    public class CreateReceiptDtoValidator : AbstractValidator<CreateReceiptDto>
    {
        public CreateReceiptDtoValidator(IStringLocalizer<AccountancyResource> localizer)
        {
            RuleFor(x => x.ReceiptType)
                .IsInEnum()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["ReceiptType"]])
                .NotEmpty()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["ReceiptType"]]);
            //
            RuleFor(x => x.ReceiptNumber)
                .NotEmpty()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["ReceiptNumber"]])
                .MaximumLength(ReceiptConst.MaxReceiptLength)
                .WithMessage(localizer[AccountancyDomainErrorCodes.MaxLength, localizer["ReceiptNumber"], ReceiptConst.MaxReceiptLength]);
            //
            RuleFor(x => x.ReceiptDate)
                .NotEmpty()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["Date"]]);
            //
            RuleFor(x => x.SafeId)
                .NotEmpty()
                .When(y => y.ReceiptType == ReceiptType.SafeOperation)
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["Safe"]]);
            //
            RuleFor(x => x.SafeId)
                .Empty()
                .When(y => y.ReceiptType != ReceiptType.SafeOperation)
                .WithMessage(localizer[AccountancyDomainErrorCodes.IsNull, localizer["Safe"]]);
            //
            RuleFor(x => x.CurrentId)
                .NotEmpty()
                .When(y => y.ReceiptType == ReceiptType.Payment || y.ReceiptType == ReceiptType.Collection)
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["Current"]]);
            //
            RuleFor(x => x.CurrentId)
                .Empty()
                .When(y => y.ReceiptType != ReceiptType.Payment && y.ReceiptType != ReceiptType.Collection)
                .WithMessage(localizer[AccountancyDomainErrorCodes.IsNull, localizer["Current"]]);
            //
            RuleFor(x => x.BankAccountId)
                .NotEmpty()
                .When(y => y.ReceiptType == ReceiptType.BankOperation)
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["BankAccount"]]);
            //
            RuleFor(x => x.BankAccountId)
                .Empty()
                .When(y => y.ReceiptType != ReceiptType.BankOperation)
                .WithMessage(localizer[AccountancyDomainErrorCodes.IsNull, localizer["BankAccount"]]);
            //
            RuleFor(x => x.MovementNumber)
                .NotNull()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["MovementNumber"]])
                .GreaterThanOrEqualTo(0)
                .WithMessage(localizer[AccountancyDomainErrorCodes.GreaterThanOrEqual, localizer["MovementNumber"], localizer["ToZero"], localizer["ThanZero"]]);
            //
            RuleFor(x => x.ChequeTotal)
                .NotNull()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["ChequeTotal"]])
                .GreaterThanOrEqualTo(0)
                .WithMessage(localizer[AccountancyDomainErrorCodes.GreaterThanOrEqual, localizer["ChequeTotal"], localizer["ToZero"], localizer["ThanZero"]]);
            //
            RuleFor(x => x.BillTotal)
                .NotNull()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["BillTotal"]])
                .GreaterThanOrEqualTo(0)
                .WithMessage(localizer[AccountancyDomainErrorCodes.GreaterThanOrEqual, localizer["BillTotal"], localizer["ToZero"], localizer["ThanZero"]]);
            //
            RuleFor(x => x.PostTotal)
                .NotNull()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["PostTotal"]])
                .GreaterThanOrEqualTo(0)
                .WithMessage(localizer[AccountancyDomainErrorCodes.GreaterThanOrEqual, localizer["PostTotal"], localizer["ToZero"], localizer["ThanZero"]]);
            //
            RuleFor(x => x.CashTotal)
                .NotNull()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["CashTotal"]])
                .GreaterThanOrEqualTo(0)
                .WithMessage(localizer[AccountancyDomainErrorCodes.GreaterThanOrEqual, localizer["CashTotal"], localizer["ToZero"], localizer["ThanZero"]]);
            //
            RuleFor(x => x.BankTotal)
                .NotNull()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["BankTotal"]])
                .GreaterThanOrEqualTo(0)
                .WithMessage(localizer[AccountancyDomainErrorCodes.GreaterThanOrEqual, localizer["BankTotal"], localizer["ToZero"], localizer["ThanZero"]]);
            //
            RuleFor(x => x.DepartmentId)
                .Must(x => x.HasValue && x.Value != Guid.Empty)
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["Department"]]);
            //
            RuleFor(x => x.TermId)
                .Must(x => x.HasValue && x.Value != Guid.Empty)
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["Term"]]);            
            //
            RuleFor(x => x.Description)
                .MaximumLength(EntityConst.MaxDescriptionLength)
                .WithMessage(localizer[AccountancyDomainErrorCodes.MaxLength, localizer["Description"], EntityConst.MaxDescriptionLength]);
            //
            RuleForEach(x => x.ReceiptDetails)
                .SetValidator(y => new ReceiptDetailDtoValidator(localizer));
        }
    }
}

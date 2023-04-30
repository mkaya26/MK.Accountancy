using FluentValidation;
using Microsoft.Extensions.Localization;
using MK.Accountancy.Consts;

namespace MK.Accountancy.Receipts
{
    public class SelectReceiptMoventValidator : AbstractValidator<SelectReceiptDetailDto>
    {
        public SelectReceiptMoventValidator(IStringLocalizer localizer)
        {
            RuleFor(x => x.ChequeBankId)
                .NotEmpty()
                .When(y => y.PaymentType == PaymentType.Cheque)
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["ChequeBank"]]);
            //
            RuleFor(x => x.ChequeBankDepartmentId)
                .NotEmpty()
                .When(y => y.PaymentType == PaymentType.Cheque)
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["BankBranch"]]);
            //
            RuleFor(x => x.ChequeAccountNumber)
                .NotEmpty()
                .When(y => y.PaymentType == PaymentType.Cheque)
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["ChequeAccountNumber"]])
                .MaximumLength(ReceiptDetailConst.MaxChequeAccountNumberLength)
                .WithMessage(localizer[AccountancyDomainErrorCodes.MaxLength, localizer["ChequeAccountNumber"], ReceiptDetailConst.MaxChequeAccountNumberLength]);
            //
            RuleFor(x => x.DocumentNo)
                .NotEmpty()
                .When(y => y.PaymentType == PaymentType.Cheque)
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["DocumentNo"]])
                .MaximumLength(ReceiptDetailConst.MaxDocumentNoLength)
                .WithMessage(localizer[AccountancyDomainErrorCodes.MaxLength, localizer["DocumentNo"], ReceiptDetailConst.MaxDocumentNoLength]);
            //
            RuleFor(x => x.PrincipalDebtor)
                .NotEmpty()
                .When(y => y.PaymentType == PaymentType.Cheque || y.PaymentType == PaymentType.Bill)
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["PrincipalDebtor"]])
                .MaximumLength(ReceiptDetailConst.MaxPrincipalDebtorLength)
                .WithMessage(localizer[AccountancyDomainErrorCodes.MaxLength, localizer["PrincipalDebtor"], ReceiptDetailConst.MaxPrincipalDebtorLength]);
            //
            RuleFor(x => x.PrincipalDebtor)
                .Empty()
                .When(y => y.PaymentType != PaymentType.Cheque && y.PaymentType != PaymentType.Bill)
                .WithMessage(localizer[AccountancyDomainErrorCodes.IsNull, localizer["PrincipalDebtor"]]);
            //
            RuleFor(x => x.Endorser)
                .MaximumLength(ReceiptDetailConst.MaxEndorserLength)
                .WithMessage(localizer[AccountancyDomainErrorCodes.MaxLength, localizer["Endorser"], ReceiptDetailConst.MaxEndorserLength]);
            //
            RuleFor(x => x.Endorser)
                .Empty()
                .When(y => y.PaymentType != PaymentType.Cheque && y.PaymentType != PaymentType.Bill)
                .WithMessage(localizer[AccountancyDomainErrorCodes.IsNull, localizer["Endorser"]]);
            RuleFor(x => x.SafeId)
    .NotEmpty()
    .When(y => y.PaymentType == PaymentType.Cash)
    .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["Safe"]]);
            //
            RuleFor(x => x.SafeId)
                .Empty()
                .When(y => y.PaymentType != PaymentType.Cash)
                .WithMessage(localizer[AccountancyDomainErrorCodes.IsNull, localizer["Safe"]]);
            //
            RuleFor(x => x.BankAccountId)
                .NotEmpty()
                .When(y => y.PaymentType == PaymentType.Bank || y.PaymentType == PaymentType.Pos)
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["BankAccount"]]);
            //
            RuleFor(x => x.BankAccountId)
                .Empty()
                .When(y => y.PaymentType != PaymentType.Bank && y.PaymentType != PaymentType.Pos)
                .WithMessage(localizer[AccountancyDomainErrorCodes.IsNull, localizer["BankAccount"]]);
            //
            RuleFor(x => x.Price)
                .NotNull()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["Amount"]])
                .GreaterThanOrEqualTo(0)
                .WithMessage(localizer[AccountancyDomainErrorCodes.GreaterThanOrEqual, localizer["Amount"], localizer["ToZero"], localizer["ThanZero"]]);
            //
            RuleFor(x => x.Description)
                .MaximumLength(EntityConst.MaxDescriptionLength)
                .WithMessage(localizer[AccountancyDomainErrorCodes.MaxLength, localizer["Description"], EntityConst.MaxDescriptionLength]);
        }
    }
}

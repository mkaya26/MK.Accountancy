using FluentValidation;
using Microsoft.Extensions.Localization;
using MK.Accountancy.Consts;
using System;

namespace MK.Accountancy.Receipts
{
    public class ReceiptDetailDtoValidator : AbstractValidator<ReceiptDetailDto>
    {
        public ReceiptDetailDtoValidator(IStringLocalizer localizer)
        {
            RuleFor(x => x.Id)
                .Must(x => x.HasValue && x.Value != Guid.Empty)
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["Id"]]);
            //
            RuleFor(x => x.PaymentType)
                .IsInEnum()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["PaymentType"]])
                .NotEmpty()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["PaymentType"]]);
            //
            RuleFor(x => x.TrackingNumber)
                .NotEmpty()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["TrackingNumber"]])
                .MaximumLength(ReceiptDetailConst.MaxTrackingNumberLength)
                .WithMessage(localizer[AccountancyDomainErrorCodes.MaxLength, localizer["TrackingNumber"], ReceiptDetailConst.MaxTrackingNumberLength]);
            //
            RuleFor(x => x.ChequeBankId)
                .NotEmpty()
                .When(y => y.PaymentType == PaymentType.Cheque)
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["ChequeBank"]]);
            //
            RuleFor(x => x.ChequeBankId)
                .Empty()
                .When(y => y.PaymentType != PaymentType.Cheque)
                .WithMessage(localizer[AccountancyDomainErrorCodes.IsNull, localizer["ChequeBank"]]);
            //
            RuleFor(x => x.ChequeBankDepartmentId)
                .NotEmpty()
                .When(y => y.PaymentType == PaymentType.Cheque)
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["ChequeBankDepartment"]]);
            //
            RuleFor(x => x.ChequeBankDepartmentId)
                .Empty()
                .When(y => y.PaymentType != PaymentType.Cheque)
                .WithMessage(localizer[AccountancyDomainErrorCodes.IsNull, localizer["ChequeBankDepartment"]]);
            //
            RuleFor(x => x.ChequeAccountNumber)
                .NotEmpty()
                .When(y => y.PaymentType == PaymentType.Cheque)
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["ChequeAccountNumber"]])
                .MaximumLength(ReceiptDetailConst.MaxChequeAccountNumberLength)
                .WithMessage(localizer[AccountancyDomainErrorCodes.MaxLength, localizer["ChequeAccountNumber"], ReceiptDetailConst.MaxChequeAccountNumberLength]);
            //
            RuleFor(x => x.ChequeAccountNumber)
                .Empty()
                .When(y => y.PaymentType != PaymentType.Cheque)
                .WithMessage(localizer[AccountancyDomainErrorCodes.IsNull, localizer["ChequeAccountNumber"]]);
            //
            RuleFor(x => x.DocumentNo)
                .NotEmpty()
                .When(y => y.PaymentType == PaymentType.Cheque)
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["DocumentNo"]])
                .MaximumLength(ReceiptDetailConst.MaxDocumentNoLength)
                .WithMessage(localizer[AccountancyDomainErrorCodes.MaxLength, localizer["DocumentNo"], ReceiptDetailConst.MaxDocumentNoLength]);
            //
            RuleFor(x => x.DocumentNo)
                .Empty()
                .When(y => y.PaymentType != PaymentType.Cheque)
                .WithMessage(localizer[AccountancyDomainErrorCodes.IsNull, localizer["DocumentNo"]]);
            //
            RuleFor(x => x.ExpiryDate)
                .NotEmpty()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["ExpiryDate"]]);
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
            //
            RuleFor(x => x.SafeId)
                .NotEmpty()
                .When(y => y.PaymentType == PaymentType.Cash)
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["Safe"]]);
            //
            RuleFor(x => x.BankAccountId)
                .NotEmpty()
                .When(y => y.PaymentType == PaymentType.Bank || y.PaymentType == PaymentType.Pos)
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["BankAccount"]]);
            //
            RuleFor(x => x.Price)
                .NotNull()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["Amount"]])
                .GreaterThanOrEqualTo(0)
                .WithMessage(localizer[AccountancyDomainErrorCodes.GreaterThanOrEqual, localizer["Amount"], localizer["ToZero"], localizer["ThanZero"]]);
            //
            RuleFor(x => x.DocumentStatu)
                .IsInEnum()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["DocumentStatu"]])
                .NotEmpty()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["DocumentStatu"]]);
            //
            RuleFor(x => x.Description)
                .MaximumLength(EntityConst.MaxDescriptionLength)
                .WithMessage(localizer[AccountancyDomainErrorCodes.MaxLength, localizer["Description"], EntityConst.MaxDescriptionLength]);
        }
    }
}

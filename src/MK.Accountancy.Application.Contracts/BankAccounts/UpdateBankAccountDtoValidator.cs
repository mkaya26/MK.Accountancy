using FluentValidation;
using Microsoft.Extensions.Localization;
using MK.Accountancy.Consts;
using MK.Accountancy.Localization;
using System;

namespace MK.Accountancy.BankAccounts
{
    public class UpdateBankAccountDtoValidator : AbstractValidator<UpdateBankAccountDto>
    {
        public UpdateBankAccountDtoValidator(IStringLocalizer<AccountancyResource> localizer)
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
            RuleFor(x => x.BankAccountType)
                .IsInEnum()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["BankAccountType"]])
                .NotEmpty()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["BankAccountType"]]);
            //
            RuleFor(x => x.BankDepartmentId)
                .Must(x => x.HasValue && x.Value != Guid.Empty)
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["BankDepartment"]]);
            //
            RuleFor(x => x.AccountId)
                .NotEmpty()
                .WithMessage(localizer[AccountancyDomainErrorCodes.Required, localizer["AccountId"]])
                .MaximumLength(BankAccountConst.MaxAccountNumberLength)
                .WithMessage(localizer[AccountancyDomainErrorCodes.MaxLength, localizer["AccountId"], BankAccountConst.MaxAccountNumberLength]);
            //
            RuleFor(x => x.Iban)
                .MaximumLength(BankAccountConst.MaxIbanNumberLength)
                .WithMessage(localizer[AccountancyDomainErrorCodes.MaxLength, localizer["Iban"], BankAccountConst.MaxIbanNumberLength]);
            //
            RuleFor(x => x.Description)
                .MaximumLength(EntityConst.MaxDescriptionLength)
                .WithMessage(localizer[AccountancyDomainErrorCodes.MaxLength, localizer["Description"], EntityConst.MaxDescriptionLength]);
        }
    }
}

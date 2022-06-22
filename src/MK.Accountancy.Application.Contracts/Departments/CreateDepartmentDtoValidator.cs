using FluentValidation;
using Microsoft.Extensions.Localization;
using MK.Accountancy.Localization;

namespace MK.Accountancy.Departments
{
    public class CreateDepartmentDtoValidator : AbstractValidator<CreateDepartmentDto>
    {
        public CreateDepartmentDtoValidator(IStringLocalizer<AccountancyResource> localizer)
        {

        }
    }
}

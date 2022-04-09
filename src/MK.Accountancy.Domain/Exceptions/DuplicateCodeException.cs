using Volo.Abp;

namespace MK.Accountancy.Exceptions
{
    public class DuplicateCodeException : BusinessException
    {
        public DuplicateCodeException(string code) : base(AccountancyDomainErrorCodes.DuplicateCode)
        {
            WithData("code", code);
        }
    }
}

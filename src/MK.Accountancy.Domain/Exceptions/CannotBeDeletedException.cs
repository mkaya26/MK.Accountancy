using Volo.Abp;

namespace MK.Accountancy.Exceptions
{
    public class CannotBeDeletedException : BusinessException
    {
        public CannotBeDeletedException():base(AccountancyDomainErrorCodes.CannotBeDeleted)
        {

        }
    }
}

using MK.Accountancy.Extensions;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace MK.Accountancy.Terms
{
    public class TermManager : DomainService
    {
        private readonly ITermRepository _termRepository;
        public TermManager(ITermRepository termRepository)
        {
            _termRepository = termRepository;
        }

        public async Task CheckCreateAsync(string code)
        {
            await _termRepository.CodeAnyAsync(code, x => x.Code == code);
        }

        public async Task CheckUpdateAsync(Guid id, string code, Term entity)
        {
            await _termRepository.CodeAnyAsync(code, x => x.Id != id && x.Code == code, entity.Code != code);
        }

        public async Task CheckDeleteAsync(Guid id)
        {
            await _termRepository.RelationalEntityAnyAsync(
                x => x.Invoices.Any(y => y.TermId == id) ||
                     x.Receipts.Any(y => y.TermId == id));
        }
    }
}

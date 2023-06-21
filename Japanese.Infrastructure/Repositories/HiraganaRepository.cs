using Japanese.Application.Contracts.Presistence;
using Japanese.Domain.Entities;
using Japanese.Infrastructure.Base;
using Japanese.Infrastructure.Persistence;

namespace Japanese.Infrastructure.Repositories;

public class HiraganaRepository : AsyncRepository<JapaneseDbContext, Hiragana>, IHiraganaRepository
{
    internal HiraganaRepository(JapaneseDbContext context)
        : base(context)
    {

    }

    protected override void ConfigureInclude()
    {
        throw new NotImplementedException();
    }

    protected override void ConfigureOrder()
    {
        throw new NotImplementedException();
    }

    protected override void ConfigureSearch()
    {
        throw new NotImplementedException();
    }
}

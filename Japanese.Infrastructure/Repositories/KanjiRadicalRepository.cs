using Japanese.Application.Contracts.Presistence;
using Japanese.Infrastructure.Persistence;

namespace Japanese.Infrastructure.Repositories;

public class KanjiRadicalRepository : IKanjiRadicalRepository
{
    private JapaneseDbContext context;

    public KanjiRadicalRepository(JapaneseDbContext context)
    {
        this.context = context;
    }
}
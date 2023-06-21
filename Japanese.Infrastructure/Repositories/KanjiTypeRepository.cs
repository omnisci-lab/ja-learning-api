using Japanese.Application.Contracts.Presistence;
using Japanese.Infrastructure.Persistence;

namespace Japanese.Infrastructure.Repositories;

public class KanjiTypeRepository : IKanjiTypeRepository
{
    private JapaneseDbContext context;

    public KanjiTypeRepository(JapaneseDbContext context)
    {
        this.context = context;
    }
}
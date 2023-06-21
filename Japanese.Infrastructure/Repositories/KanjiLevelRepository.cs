using Japanese.Application.Contracts.Presistence;
using Japanese.Infrastructure.Persistence;

namespace Japanese.Infrastructure.Repositories;

public class KanjiLevelRepository : IKanjiLevelRepository
{
    private JapaneseDbContext context;

    public KanjiLevelRepository(JapaneseDbContext context)
    {
        this.context = context;
    }
}
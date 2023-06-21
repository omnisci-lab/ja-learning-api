using Japanese.Application.Contracts.Presistence;
using Japanese.Infrastructure.Persistence;

namespace Japanese.Infrastructure.Repositories;

public class KanjiRepository : IKanjiRepository
{
    private JapaneseDbContext _context;

    internal KanjiRepository(JapaneseDbContext context)
    {
        _context = context;
    }
}

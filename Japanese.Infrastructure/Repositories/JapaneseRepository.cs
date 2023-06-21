using Japanese.Application.Contracts.Presistence;
using Japanese.Infrastructure.Persistence;

namespace Japanese.Infrastructure.Repositories;

public class JapaneseRepository : IJapaneseRepository
{
    private JapaneseDbContext _context;

    public JapaneseRepository(JapaneseDbContext context)
    {
        _context = context;
    }

    public IHiraganaRepository HiraganaRepository => new HiraganaRepository(_context);

    public IKatakanaRepository KatakanaRepository => new KatakanaRepository(_context);

    public IKanjiRepository KanjiRepository => new KanjiRepository(_context);

    public IKanjiTypeRepository KanjiTypeRepository => new KanjiTypeRepository(_context);

    public IKanjiLevelRepository KanjiLevelRepository => new KanjiLevelRepository(_context);

    public IKanjiRadicalRepository KanjiRadicalRepository => new KanjiRadicalRepository(_context);

    public ISentenceRepository SentenceRepository => new SentenceRepository(_context);


    public ICommonWordRepository CommonWordRepository => new CommonWordRepository(_context);
}

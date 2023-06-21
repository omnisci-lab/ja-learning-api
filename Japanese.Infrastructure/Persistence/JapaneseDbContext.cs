using Japanese.Domain.Entities;
using Japanese.Domain.Entities.CommonWordGroup;
using Japanese.Domain.Entities.KanjiGroup;
using Japanese.Domain.Entities.KanjiRadicalGroup;
using Japanese.Domain.Entities.SentenceGroup;
using Microsoft.EntityFrameworkCore;

namespace Japanese.Infrastructure.Persistence;

public class JapaneseDbContext : DbContext
{
    public JapaneseDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Hiragana> Hiragana { get; set; }
    public DbSet<Katakana> Katakana { get; set; }
    public DbSet<Kanji> Kanji { get; set; }
    public DbSet<KanjiLevel> KanjiLevels { get; set; }
    public DbSet<KanjiRadical> KanjiRadicals { get; set; }
    public DbSet<KanjiType> KanjiTypes { get; set; }
    public DbSet<Sentence> Sentences { get; set; }

    public DbSet<CommonWord> CommonWords { get; set; }
    public DbSet<CommonWordViMeaning> CommonWordViMeanings { get; set; }
    public DbSet<CommonWordEnMeaning> CommonWordEnMeanings { get; set; }
}

namespace Japanese.Repositories.Interfaces;

public interface IJapaneseRepository
{
    IKanjiRepository KanjiRepository { get; }
    IKanjiRadicalRepository KanjiRadicalRepository { get; }
    ISentenceRepository SentenceRepository { get; }
}

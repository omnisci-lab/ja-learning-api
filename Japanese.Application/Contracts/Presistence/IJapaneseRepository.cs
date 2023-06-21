namespace Japanese.Application.Contracts.Presistence;

public interface IJapaneseRepository
{
    IHiraganaRepository HiraganaRepository { get; }
    IKatakanaRepository KatakanaRepository { get; }
    IKanjiRepository KanjiRepository { get; }
    IKanjiTypeRepository KanjiTypeRepository { get; }
    IKanjiLevelRepository KanjiLevelRepository { get; }
    IKanjiRadicalRepository KanjiRadicalRepository { get; }
    ISentenceRepository SentenceRepository { get; }
    ICommonWordRepository CommonWordRepository { get; }
}

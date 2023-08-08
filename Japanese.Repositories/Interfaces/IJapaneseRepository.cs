namespace Japanese.Repositories.Interfaces;

public interface IJapaneseRepository
{
    IKanjidic2ExtensionRepository Kanjidic2ExtensionRepository { get; }
    IKanjiRadicalRepository KanjiRadicalRepository { get; }
    ISentenceRepository SentenceRepository { get; }
    IJMdictRepository VocabRepository { get; }
    IKanjidic2Repository Kanjidic2Repository { get; }
    IKanjiComponentRepository KanjiComponentRepository { get; }
    IJlptKanjiRepository JlptKanjiRepository { get; }
    IKankenRepository KankenRepository { get; }
    IKanaRepository KanaRepository { get; }
}
using Japanese.Core.RepositoryBase.MongoDB;

namespace Japanese.Repositories.Interfaces;

public interface IJapaneseRepository : IMasterRepository
{
    IKanjiRepository KanjiRepository { get; }
    IKanjidic2Repository Kanjidic2Repository { get; }
    IKanjiComponentRepository KanjiComponentRepository { get; }

    IKanjiRadicalRepository KanjiRadicalRepository { get; }
    ISentenceRepository SentenceRepository { get; }
    IJMdictRepository JMdictRepository { get; }
    ICommonWordRepository CommonWordRepository { get; }
    IKanaRepository KanaRepository { get; }
    IDictionaryRepository DictionaryRepository { get; }
}

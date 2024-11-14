using Japanese.Core.RepositoryBase.MongoDB;

namespace Japanese.Repositories.Interfaces;

public interface IJapaneseRepository : IMasterRepository
{
    IKanjiRepository KanjiRepository { get; }
    //IKanjidic2Repository Kanjidic2Repository { get; }
    IKanjidic2ExtensionRepository Kanjidic2ExtensionRepository { get; }
    IKanjiComponentRepository KanjiComponentRepository { get; }

    //IKanjiRadicalRepository KanjiRadicalRepository { get; }
    ISentenceRepository SentenceRepository { get; }
    IJMdictRepository JMdictRepository { get; }
    
    IKanaRepository KanaRepository { get; }
}

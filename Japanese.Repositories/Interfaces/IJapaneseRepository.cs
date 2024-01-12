using Japanese.Core.RepositoryBase.MongoDB;
using Japanese.Repositories.Implements;

namespace Japanese.Repositories.Interfaces;

public interface IJapaneseRepository : IMasterRepository
{
    IKanjidic2Repository Kanjidic2Repository { get; }
    IKanjidic2ExtensionRepository Kanjidic2ExtensionRepository { get; }
    IKanjiComponentRepository KanjiComponentRepository { get; }

    //IKanjiRadicalRepository KanjiRadicalRepository { get; }
    //ISentenceRepository SentenceRepository { get; }
    //IJMdictRepository VocabRepository { get; }
    
    //IKanaRepository KanaRepository { get; }
}

using Japanese.Core.MongoDB;
using Japanese.Core.RepositoryBase.MongoDB;
using Japanese.Repositories.Interfaces;

namespace Japanese.Repositories.Implements;

public class JapaneseRepository : MasterRepository, IJapaneseRepository
{
    public JapaneseRepository(MongoDBConfiguration configuration) 
        : base(configuration)
    {

    }

    public IKanjidic2Repository Kanjidic2Repository => new Kanjidic2Repository(Database, "Kanjidic2");

    public IKanjidic2ExtensionRepository Kanjidic2ExtensionRepository => new Kanjidic2ExtensionRepository(Database, "Kanjidic2Extensions");

    public IKanjiComponentRepository KanjiComponentRepository => new KanjiComponentRepository(Database, "KanjiComponents");



    //public IKanjiRadicalRepository KanjiRadicalRepository => new KanjiRadicalRepository(DynamoDBHelper);

    //public ISentenceRepository SentenceRepository => new SentenceRepository(DynamoDBHelper);

    //public IJMdictRepository VocabRepository => new JMdictRepository(DynamoDBHelper);



    //public IKanaRepository KanaRepository => new KanaRepository(DynamoDBHelper);
}
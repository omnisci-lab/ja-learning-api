using Japanese.Repositories.Interfaces;
using khothemegiatot.NoSQL.MongoDB;
using khothemegiatot.WebApi.Repositories.MongoDB;

namespace Japanese.Repositories.Implements;

public class JapaneseRepository : MasterRepository, IJapaneseRepository
{
    public JapaneseRepository(MongoDBConfiguration configuration) 
        : base(configuration)
    {

    }

    public IKanjidic2Repository Kanjidic2Repository => new Kanjidic2Repository(Database, "Kanjidic2");
    public IJMdictRepository JMdictRepository => new JMdictRepository(Database, "JMdict");


    public IKanjiComponentRepository KanjiComponentRepository => new KanjiComponentRepository(Database, "KanjiComponents");
    public IKanjiRadicalRepository KanjiRadicalRepository => new KanjiRadicalRepository(Database, "KanjiRadicals");
    public ISentenceRepository SentenceRepository => new SentenceRepository(Database, "Sentences");
    public IKanaRepository KanaRepository => new KanaRepository(Database, "Kana");
    public IKanjiRepository KanjiRepository => new KanjiRepository(Database, "Kanji");
    public ICommonWordRepository CommonWordRepository => new CommonWordRepository(Database, "CommonWords");
    public IDictionaryRepository DictionaryRepository => new DictionaryRepository(Database, "Dictionary");
}
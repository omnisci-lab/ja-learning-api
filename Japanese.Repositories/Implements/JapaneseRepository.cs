using Amazon.DynamoDBv2;
using Amazon.Runtime;
using Japanese.LanguageCore.Repositories;
using Japanese.Repositories.Interfaces;

namespace Japanese.Repositories.Implements;

public class JapaneseRepository : MasterRepository, IJapaneseRepository
{
    public JapaneseRepository(BasicAWSCredentials basicAWSCredentials, AmazonDynamoDBConfig dynamoDBConfig) 
        : base(basicAWSCredentials, dynamoDBConfig)
    {

    }

    public IKanjidic2ExtensionRepository Kanjidic2ExtensionRepository => new Kanjidic2ExtensionRepository(Client, Context, PocoDynamo);

    public IKanjiRadicalRepository KanjiRadicalRepository => new KanjiRadicalRepository(Client, Context, PocoDynamo);

    public ISentenceRepository SentenceRepository => new SentenceRepository(Client, Context, PocoDynamo);

    public IJMdictRepository VocabRepository => new JMdictRepository(Client, Context, PocoDynamo);

    public IKanjidic2Repository Kanjidic2Repository => new Kanjidic2Repository(Client, Context, PocoDynamo);

    public IKanjiComponentRepository KanjiComponentRepository => new KanjiComponentRepository(Client, Context, PocoDynamo);

    public IJlptKanjiRepository JlptKanjiRepository => new JlptKanjiRepository(Client, Context, PocoDynamo);

    public IKankenRepository KankenRepository => new KankenRepository(Client, Context, PocoDynamo);

    public IKanaRepository KanaRepository => new KanaRepository(Client, Context, PocoDynamo);
}
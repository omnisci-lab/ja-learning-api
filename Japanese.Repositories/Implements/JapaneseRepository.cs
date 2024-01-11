using Japanese.Core.AWS;
using Japanese.Core.AWS.Helpers;
using Japanese.Core.RepositoryBase.DynamoDB;
using Japanese.Repositories.Interfaces;

namespace Japanese.Repositories.Implements;

public class JapaneseRepository : MasterRepository, IJapaneseRepository
{
    public JapaneseRepository(IAwsService awsService) 
        : base(awsService)
    {

    }

    public IKanjidic2ExtensionRepository Kanjidic2ExtensionRepository => new Kanjidic2ExtensionRepository(DynamoDBHelper);

    public IKanjiRadicalRepository KanjiRadicalRepository => new KanjiRadicalRepository(DynamoDBHelper);

    public ISentenceRepository SentenceRepository => new SentenceRepository(DynamoDBHelper);

    public IJMdictRepository VocabRepository => new JMdictRepository(DynamoDBHelper);

    public IKanjidic2Repository Kanjidic2Repository => new Kanjidic2Repository(DynamoDBHelper);

    public IKanjiComponentRepository KanjiComponentRepository => new KanjiComponentRepository(DynamoDBHelper);

    public IKanaRepository KanaRepository => new KanaRepository(DynamoDBHelper);
}
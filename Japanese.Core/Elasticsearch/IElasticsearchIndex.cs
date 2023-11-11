using Nest;

namespace Japanese.Core;

public interface IElasticsearchIndex
{
    void CreateIndexes(IElasticClient client);
}
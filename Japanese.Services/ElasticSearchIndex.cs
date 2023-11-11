using Elasticsearch.Net;
using Japanese.Core;
using Japanese.Models;
using Nest;

namespace Japanese.Services;

public class ElasticsearchIndex: IElasticsearchIndex
{
    public void CreateIndexes(IElasticClient client)
    {
        client.Indices.Create("kanji2dic", i => i.Map<Kanjidic2ExtensionModel>(x => x.AutoMap()));
    }
}
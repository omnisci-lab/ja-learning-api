using Japanese.Core.MongoDB;
using Redis.OM.Modeling;

namespace Japanese.Models;

[Document(IndexName = "Dictionary", StorageType = StorageType.Json)]

public class DictionaryModel : MongoDBModel
{

}

using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Japanese.LanguageCore.AWS.DynamoDB;
using Japanese.LanguageCore.Repositories;
using Japanese.Models;
using Japanese.Repositories.Interfaces;

namespace Japanese.Repositories.Implements;

public class JMdictRepository : AppRepository<JMdictModel>, IJMdictRepository
{
    public JMdictRepository(IDynamoDBHelper dynamoDBHelper) 
        : base(dynamoDBHelper)
    {
    }
}

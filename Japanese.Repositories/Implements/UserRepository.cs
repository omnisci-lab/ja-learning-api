using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Japanese.LanguageCore.AWS.DynamoDB;
using Japanese.LanguageCore.Repositories;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using ServiceStack.Aws.DynamoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Japanese.Repositories.Implements
{
    public class UserRepository : AppRepository<UserModel>, IUserRepository
    {
        public UserRepository(IAmazonDynamoDB dynamoDB, IDynamoDBContext context, IPocoDynamo pocoDynamo) : base(dynamoDB, context, pocoDynamo)
        {
        }

        public async Task<UserModel> GetUserByEmailAsync(string email)
        {
            Expression keyExpression = new Expression
            {
                ExpressionStatement = "email= :emailValue",
                ExpressionAttributeValues = new Dictionary<string, DynamoDBEntry>
                {
                    { ":emailValue", email }
                }
            };
            QueryOperationConfig queryOperationConfig = new QueryOperationConfig();
            queryOperationConfig.KeyExpression = keyExpression;
            queryOperationConfig.Limit = 1;

            Table table = DynamoDBContext.GetTargetTable<UserModel>();

            Search search = table.Query(queryOperationConfig);

            List<Document> data = await search.GetNextSetAsync();

            var userModel = DynamoDBContext.FromDocuments<UserModel>(data).SingleOrDefault();

            return userModel!;
        }


    }
}

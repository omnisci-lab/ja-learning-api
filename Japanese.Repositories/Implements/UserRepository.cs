using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Japanese.LanguageCore.AWS.DynamoDB;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Japanese.Repositories.Implements
{
    public class UserRepository : DynamoDBService<UserModel>, IUserRepository
    {
        public UserRepository(IAmazonDynamoDB dynamoDBClient) : base(dynamoDBClient)
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

            Table table = Context.GetTargetTable<UserModel>();

            Search search = table.Query(queryOperationConfig);

            List<Document> data = await search.GetNextSetAsync();

            var userModel = Context.FromDocuments<UserModel>(data).SingleOrDefault();

            return userModel!;
        }


    }
}

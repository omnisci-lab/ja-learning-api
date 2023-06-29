using Amazon.DynamoDBv2.DataModel;
using Japanese.Core.CommonModels;

namespace Japanese.Models;

[DynamoDBTable("Users")]
public class UserModel : EntityBase
{
    [DynamoDBProperty("user_id")]
    public string? UserId { get; set; }
}

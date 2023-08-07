using Amazon.DynamoDBv2.DataModel;
using Japanese.Core.CommonModels;

namespace Japanese.Models;

[DynamoDBTable("Users")]
public class UserModel : EntityBase
{
    [DynamoDBProperty("user_id")]
    public string? UserId { get; set; }

    [DynamoDBProperty("fullname")]
    public string? FullName { get; set; }

    [DynamoDBProperty("email")]
    public string? Email { get; set; }

    [DynamoDBProperty("password")]
    public string? Password { get; set; }

    [DynamoDBProperty("salt")]
    public string? Salt { get; set; }

    [DynamoDBProperty("user_roles")]
    public List<string>? UserRoles { get; set; }
}
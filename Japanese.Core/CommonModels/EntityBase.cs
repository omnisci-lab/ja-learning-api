using Amazon.DynamoDBv2.DataModel;

namespace Japanese.Core.CommonModels;

public abstract class EntityBase
{
    [DynamoDBProperty("created_by")]
    public string? CreatedBy { get; set; }

    [DynamoDBProperty("created_date")]
    public DateTime? CreatedDate { get; set; }

    [DynamoDBProperty("last_modified_by")]
    public string? LastModifiedBy { get; set; }

    [DynamoDBProperty("last_modified_date")]
    public DateTime? LastModifiedDate { get; set; }

    [DynamoDBProperty("is_deleted")]
    public bool IsDeleted { get; set; }
}
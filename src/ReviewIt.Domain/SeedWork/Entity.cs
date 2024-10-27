using Amazon.DynamoDBv2.DataModel;

namespace ReviewIt.Domain.SeedWork;

public class Entity
{
    [DynamoDBHashKey]
    public Guid Id { get; protected set; }
}

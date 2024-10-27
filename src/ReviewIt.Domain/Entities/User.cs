using Amazon.DynamoDBv2.DataModel;
using ReviewIt.Domain.SeedWork;

namespace ReviewIt.Domain.Entities;


[DynamoDBTable("User")]
public sealed class User : AggregateRoot
{
    [DynamoDBProperty("Email")]
    public string? Email { get; set; }

    [DynamoDBProperty("Name")]
    public string? Name { get; set; }
}

using Amazon.DynamoDBv2.DataModel;
using ReviewIt.Domain.Entities;
using ReviewIt.Domain.Repository;

namespace ReviewIt.Infra.Data.DynamoDB.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly IDynamoDBContext _context;

    public UserRepository(IDynamoDBContext context)
    {
        _context = context;
    }

    public async Task Delete(User user, CancellationToken cancellationToken)
    {
        await _context.DeleteAsync(user, cancellationToken);
    }

    public Task<User> Get(Guid id, CancellationToken cancellationToken)
    {
        return _context.LoadAsync<User>(id, cancellationToken);
    }

    public async Task Insert(User user, CancellationToken cancellationToken)
    {
        await _context.SaveAsync(user, cancellationToken);
    }

    public async Task Update(User user, CancellationToken cancellationToken)
    {
        await _context.SaveAsync(user, cancellationToken);
    }
}

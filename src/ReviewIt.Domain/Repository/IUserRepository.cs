using ReviewIt.Domain.Entities;

namespace ReviewIt.Domain.Repository;

public interface IUserRepository
{
    public Task Insert(User user, CancellationToken cancellationToken);

    public Task<User> Get(Guid id, CancellationToken cancellationToken);

    public Task Delete(User user, CancellationToken cancellationToken);

    public Task Update(User user, CancellationToken cancellationToken);
}

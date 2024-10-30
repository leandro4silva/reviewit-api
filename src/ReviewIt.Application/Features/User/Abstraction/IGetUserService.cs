using ReviewIt.Application.Features.User.Contracts.Requests;
using ReviewIt.Application.Features.User.Contracts.Responses;

namespace ReviewIt.Application.Features.User.Abstraction;

public interface IGetUserService
{
    Task<GetUserResponse?> ExecuteAsync(GetUserRequest request, CancellationToken cancellationToken);
}

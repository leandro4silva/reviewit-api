
using ReviewIt.Application.Features.User.Abstraction;
using ReviewIt.Application.Features.User.Contracts.Requests;
using ReviewIt.Application.Features.User.Contracts.Responses;

namespace ReviewIt.Application.Features.User.Services;

public class GetUserService : IGetUserService
{
    public Task<GetUserResponse?> ExecuteAsync(GetUserRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

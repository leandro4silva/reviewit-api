using ReviewIt.Api.Models.Response;
using ReviewIt.Application.Features.User.Contracts.Requests;
using ReviewIt.Application.Features.User.Contracts.Responses;

namespace ReviewIt.Application.Features.User.Abstraction;

public interface ICreateUserService
{
    Task<CreateUserResponse?> ExecuteAsync(CreateUserRequest request, CancellationToken cancellationToken);
}

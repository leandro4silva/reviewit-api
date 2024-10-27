using AutoMapper;
using Microsoft.Extensions.Logging;
using ReviewIt.Application.Features.User.Abstraction;
using ReviewIt.Application.Features.User.Contracts.Requests;
using ReviewIt.Application.Features.User.Contracts.Responses;
using ReviewIt.Application.Helpers;
using ReviewIt.Domain.Repository;
using ReviewIt.Infra.Notifications;
using DomainEntity = ReviewIt.Domain.Entities;

namespace ReviewIt.Application.Features.User.Services;

public sealed class CreateUserService : ICreateUserService
{
    private readonly IMapper _mapper;
    private readonly ILogger<CreateUserService> _logger;
    private readonly INotificacaoService _notificacaoService;
    private readonly IUserRepository _userRepository;

    public CreateUserService(
        IMapper mapper, 
        ILogger<CreateUserService> logger, 
        INotificacaoService notificacaoService, 
        IUserRepository userRepository
    )
    {
        _mapper = mapper;
        _logger = logger;
        _notificacaoService = notificacaoService;
        _userRepository = userRepository;
    }

    public async Task<CreateUserResponse?> ExecuteAsync(CreateUserRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var user = _mapper.Map<DomainEntity.User>(request);

            await _userRepository.Insert(user, cancellationToken);

            return _mapper.Map<CreateUserResponse?>(request);
        }
        catch(Exception ex)
        {
            var msg = "Erro indefinido no cadastro de usuario";
            NotificationHelper.Notificar(ex, msg, _notificacaoService, _logger);
        }

        return default;
    }
}

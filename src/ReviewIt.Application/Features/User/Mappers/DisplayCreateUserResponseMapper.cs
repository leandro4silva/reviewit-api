
using AutoMapper;
using ReviewIt.Application.Features.User.Contracts.Requests;
using ReviewIt.Application.Features.User.Contracts.Responses;

namespace ReviewIt.Application.Features.User.Mappers;

public class DisplayCreateUserResponseMapper : IValueConverter<CreateUserRequest, DisplayCreateUserResponse>
{
    public DisplayCreateUserResponse Convert(CreateUserRequest sourceMember, ResolutionContext context)
    {
        return new DisplayCreateUserResponse()
        {
            Messagem = "Usuário criado com sucesso!",
        };
    }
}

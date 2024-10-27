using AutoMapper;
using ReviewIt.Api.Models.Response;
using ReviewIt.Application.Features.User.Contracts.Requests;
using ReviewIt.Application.Features.User.Contracts.Responses;
using DomainEntity = ReviewIt.Domain.Entities;

namespace ReviewIt.Application.Features.User.Mappers;

public sealed class UserProfile : Profile
{
    public UserProfile()
    {
        _ = CreateMap<CreateUserRequest, DomainEntity.User>()
            .ForMember(dest => dest.Id, src => src.MapFrom(c => c.Id))
            .ForMember(dest => dest.Name, src => src.MapFrom(c => c.Name))
            .ForMember(dest => dest.Email, src => src.MapFrom(c => c.Email));

        _ = CreateMap<CreateUserRequest, CreateUserResponse>()
            .ForMember(dest => dest.Id, src => src.MapFrom(c => c.Id))
            .ForMember(dest => dest.Name, src => src.MapFrom(c => c.Name))
            .ForMember(dest => dest.Email, src => src.MapFrom(c => c.Email))
            .ForMember(dest => dest.Display, src => src.ConvertUsing(new DisplayCreateUserResponseMapper(), src => src));

        _ = CreateMap<CreateUserResponse, ApiResponse<CreateUserResponse>>()
            .ForMember(dest => dest.Data, src => src.MapFrom(c => c));
    }
}

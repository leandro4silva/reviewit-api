using Amazon.DynamoDBv2;
using Amazon.Runtime.Internal;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReviewIt.Api.Models.Response;
using ReviewIt.Application.Features.User.Abstraction;
using ReviewIt.Application.Features.User.Contracts.Requests;
using ReviewIt.Application.Features.User.Contracts.Responses;

namespace ReviewIt.Api.Controllers.v1;

[ApiVersion("1.0")]
[Route("v{version:apiVersion}/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;

    public UserController(IMapper mapper)
    {
        _mapper = mapper;
    }


    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<CreateUserResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetById(
        [FromBody] CreateUserRequest request,
        [FromServices] ICreateUserService services,
        CancellationToken cancellationToken
    )
    {
        var response = await services.ExecuteAsync(request, cancellationToken);

        return response is not null ? Ok(response) : NoContent();
    }


    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<CreateUserResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(
        [FromBody] CreateUserRequest request,
        [FromServices] ICreateUserService services,
        CancellationToken cancellationToken
    )
    {
        var response = await services.ExecuteAsync(request, cancellationToken);

        var apiResponse = _mapper.Map<ApiResponse<CreateUserResponse>>(response);

        return response is not null ? CreatedAtAction(nameof(GetById), new {response.Id}, apiResponse) : NoContent();
    }
}
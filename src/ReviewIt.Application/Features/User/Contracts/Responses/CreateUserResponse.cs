using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace ReviewIt.Application.Features.User.Contracts.Responses;

[ExcludeFromCodeCoverage]
public sealed class CreateUserResponse
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("display")]
    public DisplayCreateUserResponse? Display { get; set; }
}

[ExcludeFromCodeCoverage]
public sealed class DisplayCreateUserResponse
{
    [JsonPropertyName("mensagem")]
    public string? Messagem { get; set; }
}
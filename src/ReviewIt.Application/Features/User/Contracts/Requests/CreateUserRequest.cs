using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace ReviewIt.Application.Features.User.Contracts.Requests;

[ExcludeFromCodeCoverage]
public sealed class CreateUserRequest
{
    [JsonIgnore]
    public Guid Id {
        get => Guid.NewGuid();
    }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName ("name")]
    public string? Name { get; set; }
}

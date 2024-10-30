using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace ReviewIt.Application.Features.User.Contracts.Requests;

[ExcludeFromCodeCoverage]
public sealed class GetUserRequest
{
    [JsonPropertyName("userId")]
    public Guid Id { get; set; }
}

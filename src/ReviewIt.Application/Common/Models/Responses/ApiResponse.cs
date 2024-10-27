using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace ReviewIt.Api.Models.Response;

[ExcludeFromCodeCoverage]
public sealed class ApiResponse<TData>
{
    [JsonPropertyName("data")]
    public TData? Data { get; private set; }
}

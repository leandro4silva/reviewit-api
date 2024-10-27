
namespace ReviewIt.Infra.Configuration;

public sealed class DynamoDbConfiguration
{
    public string? LocalServiceUrl { get; set; }

    public bool UseHttp { get; set; }
    
    public string? AuthenticationRegion { get; set; }

}

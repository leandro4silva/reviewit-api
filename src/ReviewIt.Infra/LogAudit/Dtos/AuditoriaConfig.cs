using System.Diagnostics.CodeAnalysis;

namespace ReviewIt.Infra.LogAudit.Dtos;

[ExcludeFromCodeCoverage]
public class AuditoriaConfig
{
    public bool Active { get; set; }

    public string QueueUrl { get; set; }
}

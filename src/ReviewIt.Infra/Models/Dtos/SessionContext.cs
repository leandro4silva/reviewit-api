namespace ReviewIt.Infra.Models.Dtos;

public sealed class SessionContext
{
    public string? Funcional { get; private set; }

    public string? NomeUsuario { get; private set; }

    public string? Ip { get; private set; }

    public string? CorrelationId { get; private set; }

    public IEnumerable<string>? GrouposToken { get; private set; } = Enumerable.Empty<string>();

    public void SetValues(string funcional, string nomeUsuario, string ip, string correlationId, IEnumerable<string>? groupToken = null)
    {
        Funcional = funcional;
        NomeUsuario = nomeUsuario;
        Ip = ip;
        CorrelationId = correlationId;
        GrouposToken = groupToken;
    }
}

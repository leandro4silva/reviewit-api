using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace ReviewIt.Infra.LogAudit.Dtos;

public enum AuditoriaOperacao
{
    [Description("consulta")]
    Consulta = 1,

    [Description("insercao")]
    Insercao = 2,
    
    [Description("atualizacao")]
    Atualizacao = 3,

    [Description("remocao")]
    Remocao = 4
}

[ExcludeFromCodeCoverage]
public class LogAuditCommand
{
    public AuditoriaOperacao Operacao { get; set; }

    public string Descricao { get; set; }

    public string ValorAnterior { get; set; }

    public string ValorNovo { get; set; }

    public LogAuditCommand(AuditoriaOperacao operacao, string descricao, string valorAnterior = "", string valorNovo = "")
    {
        Operacao = operacao;
        Descricao = descricao;
        ValorAnterior = valorAnterior;
        ValorNovo = valorNovo;
    }
}
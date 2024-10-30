using ReviewIt.Infra.LogAudit.Dtos;

namespace ReviewIt.Infra.LogAudit.Abstractions;

public interface ILogAuditService
{
    Task AuditAsync(LogAuditCommand request);

    Task AuditarLogOperacao(AuditoriaOperacao operacao, string descricao, object valorAnterior = null!, object valorNovo = null!);
}

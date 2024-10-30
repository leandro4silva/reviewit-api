using Amazon.SQS;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ReviewIt.Infra.LogAudit.Abstractions;
using ReviewIt.Infra.LogAudit.Dtos;
using ReviewIt.Infra.Models.Dtos;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace ReviewIt.Infra.LogAudit.Services;


[ExcludeFromCodeCoverage]
public class LogAuditService : ILogAuditService
{
    private readonly IAmazonSQS _sqs;
    private SessionContext _sessionUser;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger _logger;
    private readonly AuditoriaConfig _auditoriaConfig;

    private const string OrigemDaOperacao = "reviewIt";
    private const string SistemaOrigemDaOperacao = "ReviewItApi";
    private const string ForwardedForHeader = "x-forwarded-for";


    public LogAuditService(
        IAmazonSQS sqs,
        SessionContext sessionUser,
        IHttpContextAccessor httpContextAccessor,
        ILogger logger,
        AuditoriaConfig auditoriaConfig
    )
    {
        _sqs = sqs;
        _sessionUser = sessionUser;
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
        _auditoriaConfig = auditoriaConfig;
    }

    public async Task AuditarLogOperacao(AuditoriaOperacao operacao, string descricao, object valorAnterior = null, object valorNovo = null)
    {
        var log = new LogAuditCommand(
            operacao: operacao,
            descricao: descricao,
            valorAnterior: JsonSerializer.Serialize(valorAnterior),
            valorNovo: JsonSerializer.Serialize(valorNovo)
       );

        await AuditAsync(log);
    }

    public async Task AuditAsync(LogAuditCommand request)
    {
        try
        {
            if (_auditoriaConfig.Active)
            {
                _logger.LogWarning("Envio de log de auditorio do IFA esta desativado");
                return;
            }

            if (string.IsNullOrEmpty(_sessionUser.Funcional))
            {
                _logger.LogWarning("Nao foi possivel identificar o usuario que realizado a request");
                return;
            }

            var ip = GetremoteIpAddress();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            if (ex.InnerException != null)
            {
                _logger.LogError(ex.InnerException, ex.InnerException.Message);
            }
        }
    }

    private string GetremoteIpAddress()
    {
        var remoteIp = _httpContextAccessor.HttpContext!.Connection.RemoteIpAddress!.MapToIPv4().ToString();
        if (!string.IsNullOrWhiteSpace(remoteIp))
        {
            return remoteIp;
        }

        return _httpContextAccessor.HttpContext.Request.Headers[ForwardedForHeader].ToString();
    }
}

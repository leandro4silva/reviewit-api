﻿using Microsoft.Extensions.Logging;
using ReviewIt.Infra.Notifications;

namespace ReviewIt.Application.Helpers;

public sealed class NotificationHelper
{
    public static void Notificar(
        Exception ex, 
        string mensagem, 
        INotificacaoService notificacaoService,
        ILogger? logger = null)
    {
        var notificacao = CriarNotificacao(mensagem);
        notificacaoService.Adicionar(notificacao);

        logger?.LogCritical(ex, $"Mensagem: {mensagem}. Detalhes: {ex.Message}");
    }

    private static ErroResponse CriarNotificacao(string mensagem) => new() { Mesangem = mensagem };
}

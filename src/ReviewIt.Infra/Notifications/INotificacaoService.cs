namespace ReviewIt.Infra.Notifications;

public interface INotificacaoService
{
    bool ExisteNotificacao();

    void Adicionar(ErroResponse erro);

    List<ErroResponse> ObterTodos();
}

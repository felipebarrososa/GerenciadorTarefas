namespace GerenciadorTarefas.Messaging
{
    public interface IRabbitMQPublisher
    {
        void PublicarMensagem<T>(T mensagem);
    }
}

using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace GerenciadorTarefas.Messaging
{
    public class RabbitMQPublisher : IRabbitMQPublisher
    {
        public void PublicarMensagem<T>(T mensagem)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "tarefas",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(mensagem));

            channel.BasicPublish(exchange: "",
                                 routingKey: "tarefas",
                                 basicProperties: null,
                                 body: body);
        }
    }
}

using AppizsoftApp.Application.Interfaces.Services;
using RabbitMQ.Client;
using System.Text;

namespace AppizsoftApp.Infrastructure.Services
{
    public class RabbitMqEmailService : IEmailService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMqEmailService()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost", // RabbitMQ sunucu adresi
                UserName = "guest",    // RabbitMQ kullanıcı adı
                Password = "guest"     // RabbitMQ şifresi
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "email_queue", durable: true, exclusive: false, autoDelete: false, arguments: null);
        }

        public Task SendEmailAsync(string to, string subject, string body)
        {
            // E-posta gönderme işlemi burada gerçekleştirilir
            // Örnek olarak, mesajı RabbitMQ kuyruğuna gönderelim

            var message = new EmailMessage { To = to, Subject = subject, Body = body };
            var bodyBytes = Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(message));

            _channel.BasicPublish(exchange: "", routingKey: "email_queue", basicProperties: null, body: bodyBytes);

            return Task.CompletedTask;
        }
        public class EmailMessage
        {
            public string To { get; set; }        // Alıcı e-posta adresi
            public string Subject { get; set; }   // E-posta konusu
            public string Body { get; set; }      // E-posta içeriği (HTML veya düz metin)
        }

        public void Dispose()
        {
            _channel.Dispose();
            _connection.Dispose();
        }
    }

}




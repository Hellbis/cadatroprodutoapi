using CadastroProdutos.Models;
using RabbitMQ.Client;
using System;
using System.Text;

namespace CadastroProdutos.RabbiMQ
{
    public class ConnectionCategoria
    {
        public static void SendNew(Categoria categoria)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "cria_categoria",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = Newtonsoft.Json.JsonConvert.SerializeObject(categoria);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "cria_categoria",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine("Nova Categoria enviada");
            }
        }
        public static void SendUpdate(Categoria categoria)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "atualiza_categoria",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = Newtonsoft.Json.JsonConvert.SerializeObject(categoria);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "atualiza_categoria",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine("Atualizacao Categoria enviada");
            }
        }

        public static void SendDelete(int codigo)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "deleta_categoria",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = codigo.ToString();
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "deleta_categoria",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine("Delete Categoria enviado");
            }
        }
    }
}

using System;
using System.Text;
using CadastroProdutos.Dto;
using RabbitMQ.Client;

namespace CadastroProdutos.RabbiMQ
{
    public class ConnectionProduto
    {
        public static void SendNew(ProdutoDto produto)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "cria_produto",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = Newtonsoft.Json.JsonConvert.SerializeObject(produto);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "cria_produto",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine("Nova Produto enviada");
            }
        }
        public static void SendUpdate(ProdutoDto produto)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "atualiza_produto",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = Newtonsoft.Json.JsonConvert.SerializeObject(produto);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "atualiza_produto",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine("Atualizacao Produto enviada");
            }
        }

        public static void SendDelete(int codigo)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "deleta_produto",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = codigo.ToString();
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "deleta_produto",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine("Delete Produto enviado");
            }
        }
    }
}
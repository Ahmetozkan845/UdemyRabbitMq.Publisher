using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Reflection;
using System.Text;

namespace UdemyRabbitMq.Subscriber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://mgdeodss:4fD2_W6XNSgK4xRHtYVm_HSRoFcPyRrd@chimpanzee.rmq.cloudamqp.com/mgdeodss");

            using var connection = factory.CreateConnection();

            var channel = connection.CreateModel();

           // channel.QueueDeclare("hello-queue", true, false, false);

            var consumer = new EventingBasicConsumer(channel);

            channel.BasicConsume("hello-queue", true, consumer);

            consumer.Received += (object sender, BasicDeliverEventArgs e) =>
            {
                var message = Encoding.UTF8.GetString(e.Body.ToArray());
                Console.WriteLine("Gelen Mesaj" + message);
            };

            Console.ReadLine();
        }

    
    }
}

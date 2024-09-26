using RabbitMQ.Client;
using System;
using System.Text;

namespace UdemyRabbitMq.Publisher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://mgdeodss:4fD2_W6XNSgK4xRHtYVm_HSRoFcPyRrd@chimpanzee.rmq.cloudamqp.com/mgdeodss");

            using var connection = factory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare("hello-queue",true,false,false);

            string message = "hello world";

            var messageBody = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(string.Empty,"hello-queue",null,messageBody);

            Console.WriteLine("Mesaj Gönderilmiştir");

            Console.ReadLine();
        }
    }
}

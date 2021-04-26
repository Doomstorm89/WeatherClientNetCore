using Grpc.Net.Client;
using System;
using WeatherGrpcService;

namespace WeatherClientNetCore
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            string name;
            do
            {
                using var channel = GrpcChannel.ForAddress("https://localhost:5001");
                var client = new Weather.WeatherClient(channel);
                Console.Write("Введите город или stop для выхода: ");
                name = Console.ReadLine();
                var reply = await client.GetWeatherAsync(new WeatherRequest { Name = name });
                Console.WriteLine("Ответ сервера: " + reply.Message);

            } while (name!="stop");
            
        }
    }
}

using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcPoco;
using CommandService = GrpcPoco.CommandService;

namespace GrpcPocClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new CommandService.CommandServiceClient(channel);
            
            Console.WriteLine("Client started...");
            
            string input = null;

            while (input != "exit")
            {
                input = Console.ReadLine();
                var reply = await client.ExecuteCommandAsync(new CommandRequest
                {
                    Message = input,
                    Things =
                    {
                        new Thing { Type = "Property", Value = 321 },
                        new Thing { Type = "SomeOtherProperty", Value = 456 }
                    }
                });

                Console.WriteLine("Response: " + reply);
            }
        }
    }
}
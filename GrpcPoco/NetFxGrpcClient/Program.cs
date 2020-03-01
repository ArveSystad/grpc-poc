using Grpc.Core;
using GrpcPoc;
using System;
using System.Threading.Tasks;

namespace NetFxGrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Environment.SetEnvironmentVariable("GRPC_DNS_RESOLVER", "native");
            //Environment.SetEnvironmentVariable("GRPC_TRACE", "api");
            //Environment.SetEnvironmentVariable("GRPC_VERBOSITY", "debug");
            //Grpc.Core.GrpcEnvironment.SetLogger(new Grpc.Core.Logging.ConsoleLogger());

            var channel = new Channel("localhost:5000", ChannelCredentials.Insecure);  // NOTE: "Insecure" + HTTP endpoint on 5000 (ref logs on Server startup)
            var client = new CommandService.CommandServiceClient(channel);
            
            Console.WriteLine("Client started...");
            
            string input = null;

            while (input != "exit")
            {
                input = Console.ReadLine();
                var reply = await client.ExecuteCommandAsync(new CommandRequest
                {
                    Message = $"From netframework client: {input}"
                });

                Console.WriteLine("Response: " + reply);
            }
        }
    }
}

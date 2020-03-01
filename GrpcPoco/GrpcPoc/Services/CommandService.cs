using System;
using System.Threading.Tasks;
using Grpc.Core;
using GrpcPoc;

namespace GrpcPocServer.Services
{
    public class CommandService : GrpcPoc.CommandService.CommandServiceBase
    {
        public override Task<CommandResult> ExecuteCommand(CommandRequest request, ServerCallContext context)
        {
            Console.WriteLine("Received command: " + request.Message);
            foreach (var thing in request.Things)
            {
                Console.WriteLine($"{thing.Type}: {thing.Value}");
            }

            return Task.FromResult(new CommandResult()
            {
                Message = "Received message: " + request.Message,

            });
        }
    }
}

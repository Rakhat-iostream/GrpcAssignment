using CategoryServiceSE1.Services;
using Grpc.Net.Client;
using System;

namespace GrpcClient
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var categoryClient = new CategoryService.CategoryServiceClient(channel);

            var id = new Id { Id_ = "3" };

            var status = await categoryClient.DeleteCategoryAsync(id);
            Console.WriteLine(status.Code);
        }
    }
}

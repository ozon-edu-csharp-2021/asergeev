using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Ozon.MerchandiseService.Grpc;

namespace Ozon.MerchandiseService.GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new MerchandiseServiceGrpc.MerchandiseServiceGrpcClient(channel);

            var response = await client.GetMerchAsync(new GetMerchRequest(), 
                cancellationToken: CancellationToken.None);

         //  var response = await client.GetInfoAboutMerchAsync(new GetInfoAboutMerchRequest(),
           //    cancellationToken: CancellationToken.None);
           
            Console.WriteLine(response);
        }
    }
}
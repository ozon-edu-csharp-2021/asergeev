using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Ozon.MerchandiseService.HttpModels;
using Ozon.MerchandiseService.Presentation.Models;

namespace Ozon.MerchandiseService.HttpClients
{
    interface IMerchHttpClient
    {
        Task<MerchInfoResponse> GetInfoAboutMerch(EmployeeModel model, CancellationToken token);
        Task<MerchItem> RequestMerch(EmployeeModel model, CancellationToken token);
    }
    public class MerchandiseHttpClient: IMerchHttpClient
    {
        private readonly HttpClient _client;

        public MerchandiseHttpClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<MerchInfoResponse> GetInfoAboutMerch(EmployeeModel model, CancellationToken token)
        {
            var response = await _client.GetAsync("v1/api/merch",token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<MerchInfoResponse>(body);
        }
        
        public async Task<MerchItem> RequestMerch(EmployeeModel model, CancellationToken token)
        {
            var response = await _client.PostAsJsonAsync("v1/api/merch", model, token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<MerchItem>(body);
        }
    }
}
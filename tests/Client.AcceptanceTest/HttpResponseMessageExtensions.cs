using Newtonsoft.Json;

namespace Client.AcceptanceTest
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<TResponse> DeserializeAsync<TResponse>(this HttpResponseMessage httpResponse)
        {
            string content = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(content)!;
        }
        
    }
}

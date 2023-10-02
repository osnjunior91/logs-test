using CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Infrastructure.ExternalServices
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;

        public HttpClientService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<string>> FetchDataAsync(string url)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string logData = await response.Content.ReadAsStringAsync();
                    List<string> logLines = logData.Split('\n')
                    .Where(line => !string.IsNullOrWhiteSpace(line))
                    .ToList();
                    return logLines;
                }
                else
                {
                    throw new HttpRequestException($"HTTP request failed with status code {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, or take appropriate action
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}

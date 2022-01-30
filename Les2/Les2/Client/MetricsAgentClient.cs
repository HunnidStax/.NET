using System;
using MetricsManager.Responses;
using MetricsManager.Requests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Net.Http;

namespace MetricsManager.Client
{
    public class MetricsAgentClient
    {
        public class MetricsAgentClient : IMetricsAgentClient
        {
            private readonly HttpClient _httpClient;
            private readonly ILogger _logger;

            public MetricsAgentClient(HttpClient httpClient, ILogger logger)
            {
                _httpClient = httpClient;
                _logger = logger;
            }

            public AllHddMetricsApiResponses GetAllHddMetrics(HddMetricsRequest request)
            {
                var fromParameter = request.FromTime.TotalSeconds;
                var toParameter = request.ToTime.TotalSeconds;
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{request.ClientBaseAddress}/api/hddmetrics/from/{fromParameter}/to/{toParameter}");
                try
                {
                    HttpResponseMessage response = HttpClient.SendAsync(httprequest).Result;

                    using var responseStream = response.Content.ReadAsStreamAsync().Result;
                    return JsonSerializer.DeserializeAsync<AllHddMetricsApiResponses>(responseStream).Result;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }

           return null;
        }
    } 
}

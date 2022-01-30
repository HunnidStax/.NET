using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AutoMapper;
using System.Text.Json;
using System.Net.Http;
using MetricsManager.Responses;
using Amazon.DeviceFarm.Model;

namespace Les2.Controllers
{
    [Route("api/metrics/cpu")]
    [ApiController]

    public class CpuMetricsController : ControllerBase
    {
        private readonly ILogger<CpuMetricsController> _logger;
        private readonly MetricsManager.DAL.ICpuMetricsRepository _cpuMetricsRepository;
        private readonly IMapper _mapper;
        private IHttpClientFactory _clientFactory;


        public CpuMetricsController(ILogger<CpuMetricsController> logger, MetricsManager.DAL.ICpuMetricsRepository cpuMetricsRepository, IMapper mapper, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _cpuMetricsRepository = cpuMetricsRepository;
            _mapper = mapper;
            _clientFactory = clientFactory;
        }

        //public IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        //{
        //    // логируем, что мы пошли в соседний сервис
        //    _logger.LogInformation($"starting new request to metrics agent");
        //    // обращение в сервис
        //    var metrics = metricAgentClient.GetCpuMetrics(new GetAllCpuMetricsRequest
        //    {
        //        FromTime = fromTime,
        //        ToTime = toTime
        //    });

        //    // возвращаем ответ
        //    return Ok(metrics);
        //}


        [HttpGet("agent/{agentId}/from/{fromDate}/to/{toDate}")]
        public IActionResult GetMetrics([FromRoute] int agentId, [FromRoute] TimeSpan fromDate, [FromRoute] TimeSpan toDate)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            "http://localhost:50343/api/cpumetrics/from/1/to/999999?var=val&var1=val1");
            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = client.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                var metricsResponse = JsonSerializer.DeserializeAsync
                    <AllCpuMetricsApiResponses>(responseStream).Result;
            }
            else
            {
                _logger.LogError(response.ReasonPhrase);
                return Problem();
                //throw new Exception();
                //ошибка при получении ответа
            }
            return Ok();
        }
    }
}

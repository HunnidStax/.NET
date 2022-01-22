using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Les2.Controllers
{
    [Route("api/metrics/network")]
    [ApiController]
    public class NetworkMetricsController : ControllerBase
    {
        private readonly ILogger<NetworkMetricsController> _logger;
        private readonly MetricAgent.DAL.INetworkMetricRepository _networkMetricRepository;

        public NetworkMetricsController(ILogger<NetworkMetricsController> logger, MetricAgent.DAL.INetworkMetricRepository networkMetricRepository)
        {
            _logger = logger;
            _networkMetricRepository = networkMetricRepository;
        }
        [HttpGet("agent/{agentId}/from/{fromDate}/to/{toDate}")]
        public IActionResult GetMetrics([FromRoute] int agentId, [FromRoute] TimeSpan fromDate, [FromRoute] TimeSpan toDate)
        {
            _logger.LogInformation("лог работает");
            return Ok();
        }
    }
}

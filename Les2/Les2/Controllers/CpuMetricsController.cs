using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Les2.Controllers
{
    [Route("api/metrics/cpu")]
    [ApiController]

    public class CpuMetricsController : ControllerBase
    {
        private readonly ILogger<CpuMetricsController> _logger;
        private readonly MetricAgent.DAL.ICpuMetricRepository _cpuMetricRepository;

        public CpuMetricsController(ILogger<CpuMetricsController> logger, MetricAgent.DAL.ICpuMetricRepository cpuMetricRepository)
        {
            _logger = logger;
            _cpuMetricRepository = cpuMetricRepository;
        }

        [HttpGet("agent/{agentId}/from/{fromDate}/to/{toDate}")]
        public IActionResult GetMetrics([FromRoute] int agentId, [FromRoute] TimeSpan fromDate, [FromRoute] TimeSpan toDate)
        {
            return Ok();
        }
    }
}

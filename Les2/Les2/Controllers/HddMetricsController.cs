using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Les2.Controllers
{
    [Route("api/metrics/hdd")]
    [ApiController]
    public class HddMetricsController : ControllerBase
    {
        private readonly ILogger<HddMetricsController> _logger;
        private readonly MetricAgent.DAL.IHddMetricRepository _hddMetricRepository;

        public HddMetricsController(ILogger<HddMetricsController> logger, MetricAgent.DAL.IHddMetricRepository hddMetricRepository)
        {
            _logger = logger;
            _hddMetricRepository = hddMetricRepository;
        }

        [HttpGet("agentId/{agentId}/left/{TotalFreeSpace}")]
        public IActionResult GetMetrics([FromRoute] int agentId, [FromRoute] long TotalFreeSpace)
        {
            _logger.LogInformation("лог работает");
            return Ok();
        }
    }
}

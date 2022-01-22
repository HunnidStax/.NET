using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Les2.Controllers
{
    [Route("api/metrics/ram")]
    [ApiController]
    public class RamMetricsController : ControllerBase
    {
        private readonly ILogger<RamMetricsController> _logger;
        private readonly MetricAgent.DAL.IRamMetricRepository _ramMetricRepository;

        public RamMetricsController(ILogger<RamMetricsController> logger, MetricAgent.DAL.IRamMetricRepository ramMetricRepository)
        {
            _logger = logger;
            _ramMetricRepository = ramMetricRepository;
        }
        [HttpGet("agentId/{agentId}/left/{TotalFreeSpace}")]
        public IActionResult GetMetrics([FromRoute] int agentId, [FromRoute] long TotalFreeSpace)
        {
            return Ok();
        }
    }
}

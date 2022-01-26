using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace Les2.Controllers
{
    [Route("api/metrics/ram")]
    [ApiController]
    public class RamMetricsController : ControllerBase
    {
        private readonly ILogger<RamMetricsController> _logger;
        private readonly MetricAgent.DAL.IRamMetricRepository _ramMetricRepository;
        private readonly IMapper _mapper;

        public RamMetricsController(ILogger<RamMetricsController> logger, MetricAgent.DAL.IRamMetricRepository ramMetricRepository, IMapper mapper)
        {
            _logger = logger;
            _ramMetricRepository = ramMetricRepository;
            _mapper = mapper;
        }
        [HttpGet("agentId/{agentId}/left/{TotalFreeSpace}")]
        public IActionResult GetMetrics([FromRoute] int agentId, [FromRoute] long TotalFreeSpace)
        {
            return Ok();
        }
    }
}

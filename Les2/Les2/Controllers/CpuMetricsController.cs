using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Les2.Controllers
{
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        [HttpGet("agent/{agentId}/from/{fromDate}/to/{toDate}")]
        public IActionResult GetMetrics([FromRoute] int agentId, [FromRoute] TimeSpan fromDate, [FromRoute] TimeSpan toDate)
        {
            return Ok();
        }
    }
}

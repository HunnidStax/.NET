using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Les2.Controllers
{
    [Route("api/metrics/hdd")]
    [ApiController]
    public class HddMetricsController : ControllerBase
    {
        [HttpGet("left/{agentId}/from/{fromDate}/to/{toDate}")]
        public IActionResult GetMetrics([FromRoute] int agentId, [FromRoute] TimeSpan fromDate, [FromRoute] TimeSpan toDate)
        {
            return Ok();
        }
    }
}

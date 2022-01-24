using Microsoft.AspNetCore.Mvc;
using MetricAgent.DAL;
using MetricAgent.Models;
using MetricAgent.Requests;
using MetricAgent.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace MetricAgent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CpuMetricController : ControllerBase
    {
        private readonly ILogger<CpuMetricController> _logger;
        private readonly ICpuMetricRepository _cpuMetricRepository;

        public CpuMetricController(ILogger<CpuMetricController> logger, ICpuMetricRepository cpuMetricRepository)
        {
            _logger = logger;
            _cpuMetricRepository = cpuMetricRepository;
        }

        private readonly ICpuMetricRepository repository;

        public CpuMetricController(ICpuMetricRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CpuMetricCreateRequest request)
        {
            repository.Create(new CpuMetric
            {
                Time = request.Time,
                Value = request.Value
            });

            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = repository.GetAll();

            var response = new AllCpuMetricsResponse()
            {
                Metrics = new List<CpuMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(new CpuMetricDto { Time = metric.Time, Value = metric.Value, Id = metric.Id });
            }

            return Ok(response);
        }
    }
}

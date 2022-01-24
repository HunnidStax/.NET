using MetricAgent.DAL;
using MetricAgent.Models;
using MetricAgent.Requests;
using MetricAgent.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricAgent.Controllers
{
    [Route("api/metrics/hdd")]
    [ApiController]
    public class HddMetricController : ControllerBase
    {
        private readonly ILogger<HddMetricController> _logger;
        private readonly IHddMetricRepository _hddMetricRepository;

        public HddMetricController(ILogger<HddMetricController> logger, IHddMetricRepository hddMetricRepository)
        {
            _logger = logger;
            _hddMetricRepository = hddMetricRepository;
        }

        private readonly IHddMetricRepository repository;

        public HddMetricController(IHddMetricRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] HddMetricCreateRequest request)
        {
            repository.Create(new HddMetric
            {
                TotalFreeSpace = request.Value
            });

            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = repository.GetAll();

            var response = new AllHddMetricResponse()
            {
                Metrics = new List<HddMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(new HddMetricDto { Value = metric.TotalFreeSpace, Id = metric.Id });
            }

            return Ok(response);
        }
    }
}

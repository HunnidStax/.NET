using AutoMapper;
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
        //private readonly ILogger<HddMetricController> _logger;
        //private readonly IHddMetricRepository _hddMetricRepository;

        //public HddMetricController(ILogger<HddMetricController> logger, IHddMetricRepository hddMetricRepository)
        //{
        //    _logger = logger;
        //    _hddMetricRepository = hddMetricRepository;
        //}

        private readonly IHddMetricRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<HddMetricController> logger;

        public HddMetricController(ILogger<HddMetricController> logger, IHddMetricRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
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
                response.Metrics.Add(mapper.Map<HddMetricDto>(metric));
            }

            return Ok(response);
        }
    }
}

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
    [Route("api/metrics/ram")]
    [ApiController]
    public class RamMetricController : ControllerBase
    {
        //private readonly ILogger<RamMetricController> _logger;
        //private readonly IRamMetricRepository _ramMetricRepository;

        //public RamMetricController(ILogger<RamMetricController> logger, MetricAgent.DAL.IRamMetricRepository ramMetricRepository)
        //{
        //    _logger = logger;
        //    _ramMetricRepository = ramMetricRepository;
        //}

        private readonly IRamMetricRepository repository;
        private readonly IMapper mapper;

        public RamMetricController(IRamMetricRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] RamMetricCreateRequest request)
        {
            repository.Create(new RamMetric
            {
                TotalFreeSpace = request.Value
            });

            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = repository.GetAll();

            var response = new AllRamMetricsResponse()
            {
                Metrics = new List<RamMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(mapper.Map<RamMetricDto>(metric));
            }

            return Ok(response);
        }
    }
}

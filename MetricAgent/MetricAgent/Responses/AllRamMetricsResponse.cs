using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricAgent.Responses
{
    public class AllRamMetricsResponse
    {
        public List<RamMetricDto> Metrics { get; set; }
    }
    public class RamMetricDto
    {
        public int Value { get; set; }
        public int Id { get; set; }
    }
}

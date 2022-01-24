using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricAgent.Responses
{
    public class AllHddMetricResponse
    {
        public List<HddMetricDto> Metrics { get; set; }
    }
    public class HddMetricDto
    {
        public int Value { get; set; }
        public int Id { get; set; }
    }
}

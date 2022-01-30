using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Requests
{
    public class HddMetricsRequest
    {
        public int ClientBaseAddress { get; }
        public int Value { get; set; }
    }
}

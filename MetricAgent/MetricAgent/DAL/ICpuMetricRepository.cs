using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using MetricAgent.Models;

namespace MetricAgent.DAL
{
    interface ICpuMetricRepository : IRepository<CpuMetric>
    {
    }
}

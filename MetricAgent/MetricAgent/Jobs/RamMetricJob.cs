using MetricAgent.DAL;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MetricAgent.Jobs
{
    public class RamMetricJob : IJob
    {
        private IRamMetricRepository _repository;
        private PerformanceCounter _ramCounter;

        public RamMetricJob(IRamMetricRepository repository)
        {
            _repository = repository;
            _ramCounter = new PerformanceCounter("Memory", "Available");
        }

        public Task Execute(IJobExecutionContext context)
        {
            var ramUsageInMb = Convert.ToInt32(_ramCounter.NextValue());

            //var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());

            _repository.Create(new Models.RamMetric { TotalFreeSpace = ramUsageInMb });

            return Task.CompletedTask;
        }
    }
}

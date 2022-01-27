using MetricAgent.DAL;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MetricAgent.Jobs
{
    public class HddMetricJob : IJob
    {
        private IHddMetricRepository _repository;
        private PerformanceCounter _hddCounter;

        public HddMetricJob(IHddMetricRepository repository)
        {
            _repository = repository;
            _hddCounter = new PerformanceCounter("Total", "Available");

        }

        public Task Execute(IJobExecutionContext context)
        {
            var hddUsageInPercents = Convert.ToInt32(_hddCounter.NextValue());

            //var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());

            _repository.Create(new Models.HddMetric { TotalFreeSpace = hddUsageInPercents });

            return Task.CompletedTask;
        }
    }
}

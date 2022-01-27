using MetricAgent.DAL;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MetricAgent.Jobs
{
    public class NetworkMetricJob : IJob
    {
        private INetworkMetricRepository _repository;
        private PerformanceCounter _networkCounter;

        public NetworkMetricJob(INetworkMetricRepository repository)
        {
            _repository = repository;
            _networkCounter = new PerformanceCounter("Network", "% Network Time", "_Total");

        }

        public Task Execute(IJobExecutionContext context)
        {
            var NetworkUsageInPercents = Convert.ToInt32(_networkCounter.NextValue());

            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());

            _repository.Create(new Models.NetworkMetric { Time = time, Value = NetworkUsageInPercents });

            return Task.CompletedTask;
        }
    }
}

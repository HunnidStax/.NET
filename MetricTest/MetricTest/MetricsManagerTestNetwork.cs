using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Microsoft.Extensions.Logging;
using Les2.Controllers;

namespace MetricTest
{
    public class MetricsManagerTestNetwork
    {
        private Mock<ILogger<NetworkMetricsController>> _loggerMock;
        private Mock<MetricAgent.DAL.INetworkMetricRepository> _networkMetricRepositoryMock;

        public MetricsManagerTestNetwork()
        {
            _loggerMock = new Mock<ILogger<NetworkMetricsController>>();
            _networkMetricRepositoryMock = new Mock<MetricAgent.DAL.INetworkMetricRepository>();
        }

        [Fact]
        public void GetMetricsHdd_Result_Ok()
        {
            var controller = new Les2.Controllers.NetworkMetricsController(_loggerMock.Object, _networkMetricRepositoryMock.Object);
            var result = controller.GetMetrics(1, TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}

using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Les2.Controllers;
using Microsoft.Extensions.Logging;

namespace MetricTest
{
    public class CpuMetricsControllerTest
    {
        private Mock<ILogger<CpuMetricsController>> _loggerMock;
        private Mock<MetricAgent.DAL.ICpuMetricRepository> _cpuMetricRepositoryMock;

        public CpuMetricsControllerTest()
        {
            _loggerMock = new Mock<ILogger<CpuMetricsController>>();
            _cpuMetricRepositoryMock = new Mock<MetricAgent.DAL.ICpuMetricRepository>();
        }

        [Fact]
        public void GetMetricsCpu_Result_Ok()
        {
            var controller = new Les2.Controllers.CpuMetricsController(_loggerMock.Object, _cpuMetricRepositoryMock.Object);
            var result = controller.GetMetrics(1, TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}

using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Microsoft.Extensions.Logging;
using Les2.Controllers;

namespace MetricTest
{
    public class RamMetricsControllerTest
    {
        private Mock<ILogger<RamMetricsController>> _loggerMock;
        private Mock<MetricAgent.DAL.IRamMetricRepository> _ramMetricRepositoryMock;

        public RamMetricsControllerTest()
        {
            _loggerMock = new Mock<ILogger<RamMetricsController>>();
            _ramMetricRepositoryMock = new Mock<MetricAgent.DAL.IRamMetricRepository>();
        }

        [Fact]
        public void GetMetricsRam_Result_Ok()
        {
            var controller = new Les2.Controllers.RamMetricsController(_loggerMock.Object, _ramMetricRepositoryMock.Object);
            var result = controller.GetMetrics(1, 1);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}

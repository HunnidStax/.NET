using System;
using Xunit;
using Les2.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Microsoft.Extensions.Logging;

namespace MetricTest
{
    public class  HddMetricsControllerTest
    {
        private Mock<ILogger<HddMetricsController>> _loggerMock;
        private Mock<MetricAgent.DAL.IHddMetricRepository> _hddMetricRepositoryMock;

        public HddMetricsControllerTest()
        {
            _loggerMock = new Mock<ILogger<HddMetricsController>>();
            _hddMetricRepositoryMock = new Mock<MetricAgent.DAL.IHddMetricRepository>();
        }
        [Fact]
        public void GetMetricsHdd_Result_Ok()
        {
            var controller = new Les2.Controllers.HddMetricsController(_loggerMock.Object, _hddMetricRepositoryMock.Object);
            var result = controller.GetMetrics(1, 3508966);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}

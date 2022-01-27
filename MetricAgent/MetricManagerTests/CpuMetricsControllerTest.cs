using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Les2.Controllers;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace MetricTest
{
    public class CpuMetricsControllerTest
    {
        private Mock<ILogger<CpuMetricsController>> _loggerMock;
        private Mock<MetricAgent.DAL.ICpuMetricRepository> _cpuMetricRepositoryMock;
        private Mock<IMapper> _mapperMock;

        public CpuMetricsControllerTest()
        {
            _loggerMock = new Mock<ILogger<CpuMetricsController>>();
            _cpuMetricRepositoryMock = new Mock<MetricAgent.DAL.ICpuMetricRepository>();
            _mapperMock = new Mock<IMapper>();
        }

        [Fact]
        public void GetMetricsCpu_Result_Ok()
        {
            var controller = new Les2.Controllers.CpuMetricsController(_loggerMock.Object, _cpuMetricRepositoryMock.Object, _mapperMock.Object);
            var result = controller.GetMetrics(1, TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}

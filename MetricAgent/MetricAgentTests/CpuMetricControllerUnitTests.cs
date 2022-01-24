using AutoMapper;
using MetricAgent.Controllers;
using MetricAgent.DAL;
using MetricAgent.Models;
using Moq;
using System;
using Xunit;

namespace MetricAgentTests
{
    public class CpuMetricControllerUnitTests
    {
        private CpuMetricController controller;
        private Mock<ICpuMetricRepository> mock;
        private Mock<IMapper> map;

        public CpuMetricControllerUnitTests()
        {
            mock = new Mock<ICpuMetricRepository>();
            controller = new CpuMetricController(mock.Object, map.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            mock.Setup(repository => repository.Create(It.IsAny<CpuMetric>())).Verifiable();
            var result = controller.Create(new MetricAgent.Requests.CpuMetricCreateRequest { Time = TimeSpan.FromSeconds(1), Value = 50 });
            mock.Verify(repository => repository.Create(It.IsAny<CpuMetric>()), Times.AtMostOnce());
        }
    }
}

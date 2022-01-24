﻿using MetricAgent.DAL;
using MetricAgent.Models;
using MetricAgent.Controllers;
using Moq;
using Xunit;
using AutoMapper;

namespace MetricAgentTests
{
    public class RamMetricsControllerUnitTests
    {
        private RamMetricController controller;
        private Mock<IRamMetricRepository> mock;
        private Mock<IMapper> map;

        public RamMetricsControllerUnitTests()
        {
            mock = new Mock<IRamMetricRepository>();

            controller = new RamMetricController(mock.Object, map.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            mock.Setup(repository => repository.Create(It.IsAny<RamMetric>())).Verifiable();
            var result = controller.Create(new MetricAgent.Requests.RamMetricCreateRequest { Value = 50 });
            mock.Verify(repository => repository.Create(It.IsAny<RamMetric>()), Times.AtMostOnce());
        }
    }
}

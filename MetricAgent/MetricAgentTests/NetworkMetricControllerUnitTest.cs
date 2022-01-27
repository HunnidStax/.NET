using AutoMapper;
using MetricAgent.Controllers;
using MetricAgent.DAL;
using MetricAgent.Models;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace MetricAgentTests
{
    public class NetworkMetricsControllerUnitTests
    {
        private NetworkMetricController controller;
        private Mock<INetworkMetricRepository> mock;
        private Mock<IMapper> map;
        private Mock<ILogger<NetworkMetricController>> logger;

        public NetworkMetricsControllerUnitTests()
        {
            mock = new Mock<INetworkMetricRepository>();

            controller = new NetworkMetricController(logger.Object, mock.Object, map.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            mock.Setup(repository => repository.Create(It.IsAny<NetworkMetric>())).Verifiable();
            var result = controller.Create(new MetricAgent.Requests.NetworkMetricCreateRequest { Time = TimeSpan.FromSeconds(1), Value = 50 });
            mock.Verify(repository => repository.Create(It.IsAny<NetworkMetric>()), Times.AtMostOnce());
        }
    }
}

using MetricAgent.DAL;
using MetricAgent.Models;
using MetricAgent.Controllers;
using Moq;
using Xunit;

namespace MetricAgentTests
{
    public class HddMetricsControllerUnitTests
    {
        private HddMetricController controller;
        private Mock<IHddMetricRepository> mock;

        public HddMetricsControllerUnitTests()
        {
            mock = new Mock<IHddMetricRepository>();

            controller = new HddMetricController(mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            mock.Setup(repository => repository.Create(It.IsAny<HddMetric>())).Verifiable();
            var result = controller.Create(new MetricAgent.Requests.HddMetricCreateRequest { Value = 50 });
            mock.Verify(repository => repository.Create(It.IsAny<HddMetric>()), Times.AtMostOnce());
        }
    }
}

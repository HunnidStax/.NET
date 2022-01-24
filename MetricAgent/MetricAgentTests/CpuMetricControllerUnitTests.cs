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

        public CpuMetricControllerUnitTests()
        {
            mock = new Mock<ICpuMetricRepository>();

            controller = new CpuMetricController(mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // устанавливаем параметр заглушки
            // в заглушке прописываем что в репозиторий прилетит CpuMetric объект
            mock.Setup(repository => repository.Create(It.IsAny<CpuMetric>())).Verifiable();

            // выполняем действие на контроллере
            var result = controller.Create(new MetricAgent.Requests.CpuMetricCreateRequest { Time = TimeSpan.FromSeconds(1), Value = 50 });

            // проверяем заглушку на то, что пока работал контроллер
            // действительно вызвался метод Create репозитория с нужным типом объекта в параметре
            mock.Verify(repository => repository.Create(It.IsAny<CpuMetric>()), Times.AtMostOnce());
        }
    }
}

using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace MetricTest
{
    public class MetricsManagerTestRam
    {
        [Fact]
        public void GetMetricsRam_Result_Ok()
        {
            var controller = new Les2.Controllers.RamMetricsController();
            var result = controller.GetMetrics(1, TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}

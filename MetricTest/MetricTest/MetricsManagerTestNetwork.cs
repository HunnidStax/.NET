using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace MetricTest
{
    public class  MetricsManagerTestNetwork
    {
        [Fact]
        public void GetMetricsNetwork_Result_Ok()
        {
            var controller = new Les2.Controllers.NetworkMetricsController();
            var result = controller.GetMetrics(1, TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}

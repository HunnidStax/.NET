using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace MetricTest
{
    public class MetricTest
    {
        [Fact]
        public void GetMetricsCpu_Result_Ok()
        {
            var controller = new Les2.Controllers.CpuMetricsController();
            var result = controller.GetMetrics(1, TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsRam_Result_Ok()
        {
            var controller = new Les2.Controllers.RamMetricsController();
            var result = controller.GetMetrics(1, TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsDotnet_Result_Ok()
        {
            var controller = new Les2.Controllers.DotnetMetricsController();
            var result = controller.GetMetrics(1, TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsNetwork_Result_Ok()
        {
            var controller = new Les2.Controllers.NetworkMetricsController();
            var result = controller.GetMetrics(1, TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsHdd_Result_Ok()
        {
            var controller = new Les2.Controllers.HddMetricsController();
            var result = controller.GetMetrics(1, TimeSpan.Zero, TimeSpan.Zero);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}

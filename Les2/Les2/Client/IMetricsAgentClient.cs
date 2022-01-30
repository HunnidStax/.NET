using MetricsManager.Requests;
using MetricsManager.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Client
{
    interface IMetricsAgentClient
    {
        AllRamMetricsApiResponses GetAllRamMetrics(RamMetricsRequest request);

        AllHddMetricsApiResponses GetAllHddMetrics(HddMetricsRequest request);

        AllNetworkMetricsApiResponses GetDonNetMetrics(NetworkMetricsRequest request);

        AllCpuMetricsApiResponses GetCpuMetrics(CpuMetricsRequest request);

    }
}

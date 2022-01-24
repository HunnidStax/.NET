using AutoMapper;
using MetricAgent.Models;
using MetricAgent.Responses;

namespace MetricsAgent
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // добавлять сопоставления в таком стиле нужно для всех объектов 
            CreateMap<CpuMetric, CpuMetricDto>();
            CreateMap<HddMetric, HddMetricDto>();
            CreateMap<RamMetric, RamMetricDto>();
            CreateMap<NetworkMetric, NetworkMetricDto>();
        }
    }
}


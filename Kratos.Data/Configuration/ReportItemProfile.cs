using AutoMapper;

namespace Kratos.Data.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Model.ReportItem, Data.Model.ReportItem>();
                cfg.CreateMap<Model.Report, Data.Model.Report>();
            });
        }
    }
}

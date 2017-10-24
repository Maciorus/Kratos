using AutoMapper;
using Kratos.Business.Model;

namespace Kratos.Data.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ReportItem, Model.ReportItem>();
                cfg.CreateMap<Report, Model.Report>();
            });
        }
    }
}

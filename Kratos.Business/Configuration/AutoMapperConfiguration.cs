using AutoMapper;

namespace Kratos.Business.Configuration
{
  public static class AutoMapperConfiguration
  {
    public static void Configure()
    {
      Mapper.Initialize(cfg =>
      {
        cfg.AddProfile(new ReportItemProfile());
        cfg.AddProfile(new ReportProfile());
      });
    }
  }
}

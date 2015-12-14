using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kratos.Business.Configuration
{
  public class ReportItemProfile : Profile
  {
    protected override void Configure()
    {
      Mapper.CreateMap<Model.ReportItem, Data.Model.ReportItem>();
    }
  }
}

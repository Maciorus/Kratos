using System.ComponentModel;
using Castle.Windsor;
using Kratos.Business.Interfaces;
using Kratos.Business.Services;
using Kratos.Data.Configuration;

namespace Kratos.UI
{
  class Program
  {
    static void Main(string[] args)
    {
//      AutoMapperConfiguration.Configure();
      var container = new WindsorContainer();
      container.Install(new RepositoryInstaller());

      var detailsRepository = container.Resolve<IDetailsRepository>();
      var payablesRepository = container.Resolve<IPayablesRepository>();
      var receivevablesRepository = container.Resolve<IReceivevablesRepository>();
      var reportRepository = container.Resolve<IReportRepository>();

      var rc = new ReportService(payablesRepository, receivevablesRepository, detailsRepository, reportRepository);
      rc.GenerateReport();
    }
  }
}


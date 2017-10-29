using System.Collections.Generic;
using System.Reflection;
using Castle.Windsor;
using Kratos.Business.Interfaces;
using Kratos.Business.Services;
using Kratos.Utils;

namespace Kratos.UI
{
  class Program
  {
    static void Main()
    {
      var container = new WindsorContainer();

      var assemblyLoader = new AssemblyLoader(Assembly.GetExecutingAssembly(), new List<string> {"Kratos"}); 

      var installerLoader = new WindsorInstallerLoader();

      var windsorInstallers = installerLoader.GetInstallers(assemblyLoader);

      container.Install(windsorInstallers);

      var detailsRepository = container.Resolve<IDetailsRepository>();
      var payablesRepository = container.Resolve<IPayablesRepository>();
      var receivevablesRepository = container.Resolve<IReceivevablesRepository>();
      var reportRepository = container.Resolve<IReportRepository>();

      var rc = new ReportService(payablesRepository, receivevablesRepository, detailsRepository, reportRepository);
      rc.GenerateReport();
    }
  }
}


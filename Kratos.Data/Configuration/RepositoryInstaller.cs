using System.Configuration;
using System.IO;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Kratos.Business.Interfaces;
using Kratos.Data.Repositories;

namespace Kratos.Data.Configuration
{
  public class RepositoryInstaller : IWindsorInstaller
  {
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
      container.Register(Component
        .For<IPayablesRepository>()
        .ImplementedBy<FilePayablesRepository>()
        .DependsOn(Dependency.OnValue("payablesFile", new FileInfo(ConfigurationManager.AppSettings["PayablesFile"]))));

      container.Register(Component
        .For<IReceivevablesRepository>()
        .ImplementedBy<FileReceivablesRespository>()
        .DependsOn(Dependency.OnValue("receivablesFile", new FileInfo(ConfigurationManager.AppSettings["ReceivablesFile"]))));

      container.Register(Component
        .For<IDetailsRepository>()
        .ImplementedBy<FileDetailsRepository>()
        .DependsOn(Dependency.OnValue("detailsFile", new FileInfo(ConfigurationManager.AppSettings["DetailsFile"]))));

      container.Register(Component
        .For<IReportRepository>()
        .ImplementedBy<FileReportRepository>()
        .DependsOn(Dependency.OnValue("reportFile", new FileInfo(ConfigurationManager.AppSettings["ReportFile"]))));
    }
  }
}

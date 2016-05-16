using AutoMapper;
using Kratos.Business.Extensions;
using Kratos.Business.Model;
using Kratos.Data.DAL;
using Kratos.Data.Views;
using System.Configuration;
using System.IO;
using Kratos.Business.Logic.Factories;

namespace Kratos.Business.Controllers
{
  public class ReportController
  {

    PayablesView payablesView;
    ReceivablesView receivablesView;
    DetailsView detailsView;
    ReportView reportView;

    public ReportController()
    {
      payablesView = new PayablesView(new PayablesDAL(new FileInfo(ConfigurationManager.AppSettings["PayablesFile"])));
      receivablesView = new ReceivablesView(new FileInfo(ConfigurationManager.AppSettings["ReceivablesFile"]));
      detailsView = new DetailsView(new FileInfo(ConfigurationManager.AppSettings["DetailsFile"]));

      reportView = new ReportView(new ReportDAL(new FileInfo(ConfigurationManager.AppSettings["ReportFile"])));
    }

    public Report Generate()
    {
      var receivables = ReceivablesFactory.Create(receivablesView.GetAll());
      var payables = PayablesFactory.Create(payablesView.GetAll());
      
      //var documents = DictionaryExtensions.Merge(receivables.Documents, payables.Documents);

      var dupsAndMerged = DictionaryExtensions.GetDuplicateAndMerge(receivables.Documents, payables.Documents);
      var duplicates = DictionaryExtensions.Merge(receivables.Duplicates, payables.Duplicates);

      return ReportItemsFactory.Create(detailsView.GetAll(), dupsAndMerged.Item1, duplicates, dupsAndMerged.Item2);

    }

    public void Write(Report report)
    {
      reportView.Write(Mapper.Map<Data.Model.Report>(report));
    }
  }
}

using Kratos.Business.Extensions;
using Kratos.Business.Interfaces;
using Kratos.Business.Logic.Factories;
using Kratos.Business.Model;

namespace Kratos.Business.Services
{
    public class ReportService
    {
        private readonly IPayablesRepository _payablesRepository;
        private readonly IReceivevablesRepository _receivevablesRepository;
        private readonly IReportRepository _reportRepository;
        private readonly IDetailsRepository _detailsRepository;

        public ReportService(IPayablesRepository payablesRepository, IReceivevablesRepository receivevablesRepository,
            IDetailsRepository detailsRepository, IReportRepository reportRepository)
        {
            _payablesRepository = payablesRepository;
            _receivevablesRepository = receivevablesRepository;
            _reportRepository = reportRepository;
            _detailsRepository = detailsRepository;

            ////payablesView = new PayablesRepository(new PayablesDAL(new FileInfo(ConfigurationManager.AppSettings["PayablesFile"])));
            ////receivablesView = new ReceivablesView(new FileInfo(ConfigurationManager.AppSettings["ReceivablesFile"]));
            ////_detailsRepository = new DetailsRepository(new FileInfo(ConfigurationManager.AppSettings["DetailsFile"]));
            ////reportView = new ReportView(new ReportDAL(new FileInfo(ConfigurationManager.AppSettings["ReportFile"])));
        }

        public void GenerateReport()
        {
            Write(Generate());
        }

        private Report Generate()
        {
            var receivables = _receivevablesRepository.GetAll();
            var payables = _payablesRepository.GetAll();

            var dupsAndMerged = DictionaryExtensions.GetDuplicateAndMerge(receivables.Documents, payables.Documents);
            var duplicates = DictionaryExtensions.Merge(receivables.Duplicates, payables.Duplicates);

            return ReportFactory.Create(_detailsRepository.GetAll(), dupsAndMerged.Item1, duplicates, dupsAndMerged.Item2);
        }

        private void Write(Report report)
        {
            _reportRepository.Write(report);
        }
    }
}

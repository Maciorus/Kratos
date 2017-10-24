using Kratos.Business.Services;

namespace Kratos.UI
{
  class Program
  {
    static void Main(string[] args)
    {
//      AutoMapperConfiguration.Configure();

      var rc = new ReportService();
      rc.GenerateReport();
      
    }
  }
}


using Kratos.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kratos.Data.Views
{
  public class ReportView
  {
    private readonly IReportDAL _reportDal;

    public ReportView(IReportDAL reportDal)
    {
      _reportDal = reportDal;
    }

    public void Write(Model.Report report)
    {
      _reportDal.Write(report);
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kratos.Business.Controllers;
using Kratos.Business.Configuration;

namespace Kratos.UI
{
  class Program
  {
    static void Main(string[] args)
    {
      AutoMapperConfiguration.Configure();

      var rc = new ReportController();
      var report = rc.Generate();
      rc.Write(report);
    }
  }
}


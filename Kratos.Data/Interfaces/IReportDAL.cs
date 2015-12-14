using Kratos.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kratos.Data.Interfaces
{
  public interface IReportDAL
  {
    void Write(Report report);
  }
}

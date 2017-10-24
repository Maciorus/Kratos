using Kratos.Business.Model;

namespace Kratos.Business.Interfaces
{
  public interface IReportRepository
  {
    void Write(Report report);
  }
}

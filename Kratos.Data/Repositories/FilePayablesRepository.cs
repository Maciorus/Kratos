using System.IO;
using System.Linq;
using FileHelpers;
using Kratos.Business.Interfaces;
using Kratos.Business.Model;
using Kratos.Data.Factories;
using Kratos.Data.Model;

namespace Kratos.Data.Repositories
{
  public class FilePayablesRepository : IPayablesRepository
  {
    private readonly FileHelperEngine<RawPayable> _payablesEngine;
    private readonly FileInfo _payablesFile;

    public FilePayablesRepository(FileInfo payablesFile)
    {
      _payablesEngine = new FileHelperEngine<RawPayable>();
      _payablesFile = payablesFile;
    }
   
    public Payables GetAll()
    {
      return PayablesFactory.Create(_payablesEngine.ReadFile(_payablesFile.FullName).ToList());
    }
  }
}

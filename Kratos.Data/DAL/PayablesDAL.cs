using FileHelpers;
using Kratos.Data.Interfaces;
using Kratos.Data.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kratos.Data.DAL
{
  public class PayablesDAL : IPayablesDAL
  {
    private readonly FileHelperEngine<RawPayable> _payablesEngine;
    private readonly FileInfo _payablesFile;

    public PayablesDAL(FileInfo payablesFile)
    {
      _payablesEngine = new FileHelperEngine<RawPayable>();
      _payablesFile = payablesFile;
    }

    public List<RawPayable> GetAll()
    {
      return _payablesEngine.ReadFile(_payablesFile.FullName).ToList();
    }
  }
}

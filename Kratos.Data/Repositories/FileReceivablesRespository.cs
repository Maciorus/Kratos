using System.Collections.Generic;
using System.IO;
using System.Linq;
using FileHelpers;
using Kratos.Business.Interfaces;
using Kratos.Business.Model;
using Kratos.Data.Factories;
using Kratos.Data.Model;

namespace Kratos.Data.Repositories
{
  public class FileReceivablesRespository : IReceivevablesRepository
  {
    private readonly FileHelperEngine<RawReceivable> _receiveablesEngine;
    private readonly FileInfo _receivablesFile;

    public FileReceivablesRespository(FileInfo receivablesFile)
    {
      _receiveablesEngine = new FileHelperEngine<RawReceivable>();
      _receivablesFile = receivablesFile;
    }

    public Receivables GetAll()
    {
      return ReceivablesFactory.Create(_receiveablesEngine.ReadFile(_receivablesFile.FullName).ToList());
    }
  }
}

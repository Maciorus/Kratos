using System.Collections.Generic;
using System.IO;
using System.Linq;

using FileHelpers;

using Kratos.Data.Model;

namespace Kratos.Data.Views
{
  public class ReceivablesView 
  {
    private readonly FileHelperEngine<RawReceivable> _receiveablesEngine;
    private readonly FileInfo _receivablesFile;

    public ReceivablesView(FileInfo receivablesFile)
    {
      _receiveablesEngine = new FileHelperEngine<RawReceivable>();
      _receivablesFile = receivablesFile;
    }

    public List<RawReceivable> GetAll()
    {
      return _receiveablesEngine.ReadFile(_receivablesFile.FullName).ToList();
    }
  }
}

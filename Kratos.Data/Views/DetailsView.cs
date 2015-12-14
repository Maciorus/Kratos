using System.Collections.Generic;
using System.IO;
using System.Linq;

using FileHelpers;

using Kratos.Data.Model;
using Kratos.Data.Interfaces;

namespace Kratos.Data.Views
{
  public class DetailsView 
  {
    private readonly FileHelperEngine<RawDetail> _detailsEngine;
    private readonly FileInfo _detailsFile;

    public DetailsView(FileInfo detailsFile)
    {
      _detailsEngine = new FileHelperEngine<RawDetail>();
      _detailsFile = detailsFile;
    }

    public List<RawDetail> GetAll()
    {
      return _detailsEngine.ReadFile(_detailsFile.FullName).ToList();
    }
  }
}

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
  public class FileDetailsRepository : IDetailsRepository
  {
    private readonly FileHelperEngine<RawDetail> _detailsEngine;
    private readonly FileInfo _detailsFile;

    public FileDetailsRepository(FileInfo detailsFile)
    {
      _detailsEngine = new FileHelperEngine<RawDetail>();
      _detailsFile = detailsFile;
    }

    public List<Detail> GetAll()
    {
      return DetailFactory.Create(_detailsEngine.ReadFile(_detailsFile.FullName).ToList());
    }
  }
}

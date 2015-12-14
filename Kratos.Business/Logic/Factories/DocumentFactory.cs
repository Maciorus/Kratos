using System.Globalization;
using Kratos.Business.Model;
using Kratos.Data.Interfaces;

namespace Kratos.Business.Logic.Factories
{
  public class DocumentFactory
  {
    private static readonly CultureInfo Culture = new CultureInfo("de-DE");

    public static Document Create(IRawView receivable, ulong documentId, Company company, DocumentType type)
    {
      return new Document()
      {
        Company = company,
        Number = documentId,
        Reference = receivable.Reference,
        Type = type,
        Amount = decimal.Parse(receivable.Amount, Culture),
        Currency = receivable.Currency,
        PoundAmount = decimal.Parse(receivable.PoundAmount, Culture)
      };
    }
  }
}

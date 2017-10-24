using Kratos.Business.Model;
using ReportItem = Kratos.Business.Model.ReportItem;

namespace Kratos.Business.Logic.Factories
{
  public class ReportItemFactory
  {
    public static ReportItem Create(Detail detail, Document document, int itemId)
    {
      return Create(
        detail, 
        document.Company.Name, 
        document.Number, 
        document.Currency, 
        document.Amount,
        itemId);
    }

    public static ReportItem Create(Detail detail, ulong documentId, int itemId)
    {
      return Create(
        detail, 
        string.Empty,
        documentId,
        string.Empty, 
        null,
        itemId);
    }

    private static ReportItem Create(Detail detail, string companyName, ulong documentId, string currency, decimal? amount, int itemId)
    {
      if (currency == "GBP")
      {
        amount = null;
      }

      return new ReportItem()
      {
        ItemId = itemId,
        Company = companyName,
        Date = detail.Date,
        Reference = detail.Reference,
        DocumentNumber = documentId,
        Currency = currency,
        Trs = detail.TRS,
        Amount = amount,
        Net = detail.Net,
        VAT = detail.VAT,
        Total = detail.Total
      };
    }
  }
}

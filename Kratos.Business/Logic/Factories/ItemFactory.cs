using System;
using System.Globalization;
using Kratos.Business.Model;
using Kratos.Data.Model;
using ReportItem = Kratos.Business.Model.ReportItem;

namespace Kratos.Business.Logic.Factories
{
  public class ItemFactory
  {
    private static readonly CultureInfo Culture = new CultureInfo("de-DE");

    public static ReportItem Create(RawDetail rawDetail, Document document, int itemId)
    {
      return Create(
        rawDetail, 
        document.Company.Name, 
        document.Number, 
        document.Currency, 
        document.Amount,
        itemId);
    }

    public static ReportItem Create(RawDetail rawDetail, ulong documentId, int itemId)
    {
      return Create(
        rawDetail, 
        string.Empty,
        documentId,
        string.Empty, 
        null,
        itemId);
    }

    private static ReportItem Create(RawDetail rawDetail, string companyName, ulong documentId, string currency, decimal? amount, int itemId)
    {
      var dateTime = DateTime.ParseExact(rawDetail.Col11, "yyyy.MM.dd", CultureInfo.InvariantCulture);

      if (currency == "GBP")
      {
        amount = null;
      }

      return new ReportItem()
      {
        ItemId = itemId,
        Company = companyName,
        Date = dateTime,
        Reference = rawDetail.Col15,
        DocumentNumber = documentId,
        Currency = currency,
        Trs = rawDetail.Col20,
        Amount = amount,
        Net = decimal.Parse(rawDetail.Col22, Culture),
        VAT = decimal.Parse(rawDetail.Col25, Culture),
        Total = decimal.Parse(rawDetail.Col28, Culture),
      };
    }
  }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using Kratos.Business.Model;
using Kratos.Data.Model;

namespace Kratos.Data.Factories
{
  public class DetailFactory
  {
    private static readonly CultureInfo Culture = new CultureInfo("de-DE");

    public static List<Detail> Create(List<RawDetail> rawList)
    {
      var details = new List<Detail>();

      var row = 1;

      foreach (var rawDetail in rawList)
      {
        var detail = new Detail()
        {
          RowId = row++,
          GroupCell = rawDetail.Col3,
          TRS = rawDetail.Col20,
          Reference = rawDetail.Col15
      };

        if (ulong.TryParse(rawDetail.Col14, out var documentId))
        {
          detail.DocumentId = documentId;

          detail.Date = DateTime.ParseExact(rawDetail.Col11, "yyyy.MM.dd", CultureInfo.InvariantCulture);
          detail.Net = decimal.Parse(rawDetail.Col22, Culture);
          detail.VAT = decimal.Parse(rawDetail.Col25, Culture);
          detail.Total = decimal.Parse(rawDetail.Col28, Culture);
        }

        details.Add(detail);
      }

      return details;
    }
  }
}

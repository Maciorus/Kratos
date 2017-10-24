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

            foreach (var rawDetail in rawList)
            {
                ulong.TryParse(rawDetail.Col14, out var documentId);

                var dateTime = DateTime.ParseExact(rawDetail.Col11, "yyyy.MM.dd", CultureInfo.InvariantCulture);

                var item = new Detail()
                {
                    DocumentId = documentId,
                    GroupCell = rawDetail.Col3,
                    TRS = rawDetail.Col20,
                    Reference = rawDetail.Col15,
                    Date = dateTime,
                    Net = decimal.Parse(rawDetail.Col22, Culture),
                    VAT = decimal.Parse(rawDetail.Col25, Culture),
                    Total = decimal.Parse(rawDetail.Col28, Culture)
                };

                details.Add(item);
            }

            return details;

        }
    }
}
